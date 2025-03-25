using System.Data;
using System.Data.SqlClient;
using WebApp.Models.Entidades;
using WebApp.Models.Enums;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Repositories;

namespace WebApp.Models.Context;

public class ContextDataSqlServer : IContextData
{
    private readonly SqlConnection? _connection;

    public ContextDataSqlServer(IConnectionManager connectionManager)
    {
        _connection = connectionManager.GetConnection();
    }
    public void Cadastrar(Livro livro)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id; //seta valor para o parâmetro "@id" no comando SQL
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
            command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
            command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;
            command.Parameters.Add("@idStatusLivro", SqlDbType.Int).Value = (int)livro.Status;
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if(_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public List<Livro> Listar()
    {
        var livros = new List<Livro>();
        try
        {
            var query = SqlManager.GetSql(TSql.LISTAR_LIVROS); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão
            var dataset = new DataSet(); //funciona como banco em memória
            var adapter = new SqlDataAdapter(command); //consegue executar comandos para poder capturar os dados
            adapter.Fill(dataset);

            var rows = dataset.Tables[0].Rows; //necessário abrir dataset para acessar linhas e colunas da tabela

            foreach (DataRow item in rows)
            {
                var colunas = item.ItemArray;

                var id = colunas[0].ToString();
                var nome = colunas[1].ToString();
                var autor = colunas[2].ToString();
                var editora = colunas[3].ToString();

                var livro = new Livro { Id = id, Nome = nome, Autor = autor, Editora = editora };
                livros.Add(livro);
            }

            adapter = null;
            dataset = null;

            return livros;
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if(_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public Livro ObterPorId(string id)
    {
        var livro = new Livro();
        try
        {
            var query = SqlManager.GetSql(TSql.PESQUISAR_LIVRO); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            var dataset = new DataSet(); //funciona como banco em memória
            var adapter = new SqlDataAdapter(command); //consegue executar comandos para poder capturar os dados
            adapter.Fill(dataset);

            var rows = dataset.Tables[0].Rows; //necessário abrir dataset para acessar linhas e colunas da tabela

            foreach (DataRow item in rows)
            {
                var colunas = item.ItemArray;

                var codigo = colunas[0].ToString();
                var nome = colunas[1].ToString();
                var autor = colunas[2].ToString();
                var editora = colunas[3].ToString();

                livro = new Livro
                {
                    Id = codigo, Nome = nome, Autor = autor, Editora = editora
                };
            }

            adapter = null;
            dataset = null;

            return livro;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if(_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public void Atualizar(Livro livro)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.ATUALIZAR_LIVRO); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id; //seta valor para o parâmetro "@id" no comando SQL
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
            command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
            command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if(_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public void Excluir(string id)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.EXCLUIR_LIVRO); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id; //seta valor para o parâmetro "@id" no comando SQL
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if(_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }
}