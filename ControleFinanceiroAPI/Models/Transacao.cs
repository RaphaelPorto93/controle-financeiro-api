namespace ControleFinanceiroAPI.Models;

public class Transacao
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public string Tipo { get; set; } = "Despesa";
    public string Categoria { get; set; } = string.Empty;
}