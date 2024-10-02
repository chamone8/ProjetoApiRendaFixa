using Microsoft.EntityFrameworkCore;
using ProjetoApiRendaFixa.CQRS.Commands.Handlers;
using ProjetoApiRendaFixa.CQRS.Queries.Handlers;
using ProjetoApiRendaFixa.Data.Repositories;
using ProjetoApiRendaFixa.Data.UnitOfWork;
using ProjetoApiRendaFixa.Infrastructure.Database;
using ProjetoApiRendaFixa.Services.Command;
using ProjetoApiRendaFixa.Services.Query;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método é chamado pelo contêiner de injeção de dependência para adicionar serviços ao contêiner.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        // Adiciona suporte ao MVC
        services.AddControllers();

        // Configuração do banco de dados SQLite
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        // Repositórios
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();

        services.AddScoped<IAccountQueryService, AccountQueryService>();
        services.AddScoped<IAccountCommandService, AccountCommandService>();
        
        services.AddScoped<GetAccountByIdQueryHandler>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICustomerPurchaseRepository, CustomerPurchaseRepository>();

        // Serviços
        services.AddScoped<IProductQueryService, ProductQueryService>();
        services.AddScoped<IProductCommandService, ProductCommandService>();
        services.AddScoped<IPurchaseQueryService, PurchaseQueryService>();



        // Handlers para CQRS
        services.AddScoped<GetProductsQueryHandler>();
        services.AddScoped<AccountCommandHandler>();
        services.AddScoped<GetAccountByIdQueryHandler>();
        services.AddScoped<PurchaseProductCommandHandler>();
        services.AddScoped<GetAccountAllQueryHandler>();
        services.AddScoped<GetAllPurchasesByAccountHandler>();
        services.AddScoped<CreateProductCommandHandler>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Configuração do Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAllOrigins");


        app.UseAuthorization();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
