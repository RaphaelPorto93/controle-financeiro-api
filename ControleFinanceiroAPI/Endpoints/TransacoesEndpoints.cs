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
    app.MapGet("/transacoes/{id}", async (int id, AppDbContext db) =>
        await db.Transacoes.FindAsync(id) is Transacao transacao
            ? Results.Ok(transacao)
            : Results.NotFound());

    app.MapPut("/transacoes/{id}", async (int id, Transacao input, AppDbContext db) =>
    {
        var transacao = await db.Transacoes.FindAsync(id);
        if (transacao is null) return Results.NotFound();

        transacao.Descricao = input.Descricao;
        transacao.Valor = input.Valor;
        transacao.Data = input.Data;
        transacao.Tipo = input.Tipo;
        transacao.Categoria = input.Categoria;

        await db.SaveChangesAsync();
        return Results.Ok(transacao);
    });

    app.MapDelete("/transacoes/{id}", async (int id, AppDbContext db) =>
    {
        var transacao = await db.Transacoes.FindAsync(id);
        if (transacao is null) return Results.NotFound();

        db.Transacoes.Remove(transacao);
        await db.SaveChangesAsync();
        return Results.NoContent();
        });
    }
}
