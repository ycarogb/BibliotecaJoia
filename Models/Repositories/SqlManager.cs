using WebApp.Models.Enums;

namespace WebApp.Models.Repositories;

public static class SqlManager
{
    public static string GetSql(TSql operacaoSql)
    {
        var sql = operacaoSql switch
        {
            TSql.LISTAR_LIVROS => "select convert(varchar(36), id) 'id', nome, autor, editora, idStatusLivro from Livros order by nome",
            TSql.CADASTRAR_LIVRO => "insert into Livros (id, nome, autor, editora, idStatusLivro) values (convert(binary(36), @id) , @nome, @autor, @editora, @idStatusLivro)",
            TSql.PESQUISAR_LIVRO => "select convert(varchar(36), id) 'id', nome, autor, editora from Livros where id = @id",
            TSql.EXCLUIR_LIVRO => "delete from Livros where id = @id",
            TSql.ATUALIZAR_LIVRO => "update Livros set nome = @nome, autor = @autor, editora = @editora, idStatusLivro = @idStatusLivro where id = @id",
            
            TSql.EMPRESTAR_LIVRO => "insert into EmprestimoLivro (idLivro, idUsuario, dataEmprestimo, dataDevolucao) values (@idLivro,  @idUsuario, @dataEmprestimo, @dataDevolucao)",
            TSql.LISTAR_LIVROS_EMPRESTADOS => "select convert(varchar(36), id) 'id', nome, autor, editora, idStatusLivro from Livros l join EmprestimoLivro el on l.id = el.idLivro where el.idUsuario = @idUsuario order by nome ",
            TSql.PESQUISAR_EMPRESTIMO => "select idEmprestimo, idLivro, idUsuario, dataEmprestimo, dataDevolucao from EmprestimoLivro where idLivro = @idLivro and idUsuario = @idUsuario",
            TSql.ATUALIZAR_EMPRESTIMO => "update EmprestimoLivro set idLivro = @idLivro, idUsuario = @idUsuario, dataEmprestimo = @dataEmprestimo, dataDevolucao = @dataDevolucao, dataDevolucaoEfetiva = @dataDevolucaoEfetiva where idEmprestimo = @idEmprestimo",
            
            TSql.LISTAR_CLIENTES => "select convert(varchar(36), id) 'id', nome, cpf, email, telefone, idStatusCliente from Clientes",
            TSql.CADASTRAR_CLIENTE => "insert into Clientes (id, nome, cpf, email, telefone, idStatusCliente) values (convert(binary(36), @id) , @nome, @cpf, @email, @telefone, @idStatusCliente)",
            TSql.PESQUISAR_CLIENTE => "select convert(varchar(36), id) 'id', nome, cpf, email, telefone, idStatusCliente from Clientes where id = @id",
            TSql.EXCLUIR_CLIENTE => "delete from Clientes where id = @id",
            TSql.ATUALIZAR_CLIENTE => "update Clientes set nome = @nome, email = @email, telefone = @telefone, idStatusCliente = @idStatusCliente where convert(varchar(36), id) = @id",
            
            TSql.LISTAR_USUARIOS => "select  id, login, senha from Usuario",
            TSql.CADASTRAR_USUARIO => "insert into Usuario (id, login, senha) values @id, @login, @senha)",
            TSql.PESQUISAR_USUARIO => "select id, login, senha from Usuario where id = @id",
            TSql.EXCLUIR_USUARIO => "delete from Usuario where id = @id",
            TSql.ATUALIZAR_USUARIO => "update Usuario set login = @login, senha = @senha where id = @id",
            TSql.EFETUAR_LOGIN => "select id, login, senha from Usuario where login = @login and senha = @senha",
            
            _ => throw new ArgumentOutOfRangeException(nameof(operacaoSql), operacaoSql, null)
            
        };

        return sql;
    }
}