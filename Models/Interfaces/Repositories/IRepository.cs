namespace WebApp.Models.Interfaces.Repositories;

public interface IRepository<T, Y>
{
    void Cadastrar(T usuario);
    List<T> Listar();
    T ObterPorId(Y id);
    void Atualizar(T usuario);
    void Excluir(Y id);
}