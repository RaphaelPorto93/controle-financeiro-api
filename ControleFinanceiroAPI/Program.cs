using Microsoft.EntityFrameworkCore;
using ControleFinanceiroAPI.Data;
using ControleFinanceiroAPI.Models;
using ControleFinanceiroAPI.Endpoints;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=financeiro.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Controle Financeiro API",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle Financeiro API V1");
});

app.MapTransacoesEndpoints();
app.MapCategoriaEndpoints();

app.Run();
