using WebApp.Models.Enums;

namespace WebApp.Models.Repositories;

public class SqlManager
{
    public static string GetSql(TSql operacaoSql)
    {
        var sql = operacaoSql switch
        {
            TSql.LISTAR_LIVROS => "select id, nome, autor, editora from Livros order by nome",
            TSql.CADASTRAR_LIVRO => "insert into Livros (id, nome, autor, editora) values (@id, @nome, @autor, @editora)",
            TSql.PESQUISAR_LIVRO => "select id, nome, autor, editora from Livros where id = @id",
            TSql.EXCLUIR_LIVRO => "delete from Livros where id = @id",
            TSql.ATUALIZAR_LIVRO => "update Livros set nome = @nome, autor = @autor, editora = @editora where id = @id",
            _ => throw new ArgumentOutOfRangeException(nameof(operacaoSql), operacaoSql, null)
        };

        return sql;
    }
}