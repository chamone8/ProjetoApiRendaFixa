using Microsoft.AspNetCore.Hosting;
using ProjetoApiRendaFixa;

var builder = WebApplication.CreateBuilder(args);

// Chame a Startup para configurar os servi�os
var startup = new Startup(builder.Configuration);

// Configure os servi�os chamando o m�todo da classe Startup
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure o pipeline de middlewares chamando o m�todo da classe Startup
startup.Configure(app, app.Environment);

// Execute a aplica��o
app.Run();

app.UseCors("AllowAllOrigins");
