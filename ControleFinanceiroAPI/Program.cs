using Microsoft.EntityFrameworkCore;
using ControleFinanceiroAPI.Data;
using ControleFinanceiroAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=financeiro.db"));

var app = builder.Build();

app.MapGet("/transacoes", async (AppDbContext db) =>
    await db.Transacoes.ToListAsync());

app.Run();