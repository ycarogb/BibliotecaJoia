namespace WebApp.Models.Entidades;

public class EmprestimoLivro
{
    public EmprestimoLivro()
    {
        DataEmprestimo = DateTime.Now.Date;
        DataDevolucao = DateTime.Now.AddDays(15).Date;
    }
    public int Id { get; set; }
    public string LivroId { get; set; }
    public string UsuarioId { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao { get; set; }
}