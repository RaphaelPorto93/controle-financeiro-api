using ControleFinanceiroAPI.Data;
using ControleFinanceiroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroAPI.Endpoints;

public static class TransacoesEndpoints
{
    public static void MapTransacoesEndpoints(this WebApplication app)
    {
        app.MapGet("/transacoes", async (AppDbContext db) =>
            await db.Transacoes.ToListAsync());

        app.MapPost("/transacoes", async (Transacao transacao, AppDbContext db) =>
        {
            db.Transacoes.Add(transacao);
            await db.SaveChangesAsync();
            return Results.Created($"/transacoes/{transacao.Id}", transacao);
        });
    }
}
