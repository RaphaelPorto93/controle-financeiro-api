using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiroAPI.Models;

public class Categoria
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    public List<Transacao>? Transacoes { get; set; }
}
