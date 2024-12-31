namespace WebApp.Models.Entidades;

public class EmprestimoLivro
{
    public string ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public string LivroId { get; set; }
    public Livro Livro { get; set; }
    public string UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
    public string DataDevolucaoEfetiva { get; set; }
}