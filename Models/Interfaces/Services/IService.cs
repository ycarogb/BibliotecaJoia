namespace WebApp.Models.Interfaces.Services;

public interface IService<T, Y>
{
    void Cadastrar(T entidade);
    List<T> Listar();
    T ObterPorId(Y id);
    void Editar(T entidade);
    void Excluir(Y id);
}