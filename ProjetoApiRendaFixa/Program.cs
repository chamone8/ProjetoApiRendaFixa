using Microsoft.AspNetCore.Hosting;
using ProjetoApiRendaFixa;

var builder = WebApplication.CreateBuilder(args);

// Chame a Startup para configurar os serviços
var startup = new Startup(builder.Configuration);

// Configure os serviços chamando o método da classe Startup
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure o pipeline de middlewares chamando o método da classe Startup
startup.Configure(app, app.Environment);

// Execute a aplicação
app.Run();

app.UseCors("AllowAllOrigins");
