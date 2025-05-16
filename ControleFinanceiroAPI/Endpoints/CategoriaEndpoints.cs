using ControleFinanceiroAPI.Data;
using ControleFinanceiroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroAPI.Endpoints;

public static class CategoriaEndpoints
{
    public static void MapCategoriaEndpoints(this WebApplication app)
    {
        app.MapGet("/categorias", async (AppDbContext db) =>
            await db.Categorias.ToListAsync());

        app.MapPost("/categorias", async (Categoria categoria, AppDbContext db) =>
        {
            db.Categorias.Add(categoria);
            await db.SaveChangesAsync();
            return Results.Created($"/categorias/{categoria.Id}", categoria);
        
    app.MapGet("/categorias/{id}", async (int id, AppDbContext db) =>
        await db.Categorias.FindAsync(id) is Categoria categoria
            ? Results.Ok(categoria)
            : Results.NotFound());

    app.MapPut("/categorias/{id}", async (int id, Categoria input, AppDbContext db) =>
    {
        var categoria = await db.Categorias.FindAsync(id);
        if (categoria is null) return Results.NotFound();

        categoria.Nome = input.Nome;
        await db.SaveChangesAsync();
        return Results.Ok(categoria);
    });

    app.MapDelete("/categorias/{id}", async (int id, AppDbContext db) =>
    {
        var categoria = await db.Categorias.FindAsync(id);
        if (categoria is null) return Results.NotFound();

        db.Categorias.Remove(categoria);
        await db.SaveChangesAsync();
        return Results.NoContent();
    });

        });
    }
}
