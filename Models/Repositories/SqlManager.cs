using WebApp.Models.Enums;

namespace WebApp.Models.Repositories;

public static class SqlManager
{
    public static string GetSql(TSql operacaoSql)
    {
        var sql = operacaoSql switch
        {
            TSql.LISTAR_LIVROS => "select convert(varchar(36), id) 'id', nome, autor, editora from Livros order by nome",
            TSql.CADASTRAR_LIVRO => "insert into Livros (id, nome, autor, editora, idStatusLivro) values (convert(binary(36), @id) , @nome, @autor, @editora, @idStatusLivro)",
            TSql.PESQUISAR_LIVRO => "select convert(varchar(36), id) 'id', nome, autor, editora from Livros where id = @id",
            TSql.EXCLUIR_LIVRO => "delete from Livros where id = @id",
            TSql.ATUALIZAR_LIVRO => "update Livros set nome = @nome, autor = @autor, editora = @editora where id = @id",
            
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
            
            _ => throw new ArgumentOutOfRangeException(nameof(operacaoSql), operacaoSql, null)
        };

        return sql;
    }
}