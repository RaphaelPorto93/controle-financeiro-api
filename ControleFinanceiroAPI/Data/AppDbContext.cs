using Microsoft.EntityFrameworkCore;
using ControleFinanceiroAPI.Models;

namespace ControleFinanceiroAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Transacao> Transacoes => Set<Transacao>();
    public DbSet<Categoria> Categorias => Set<Categoria>();


}
