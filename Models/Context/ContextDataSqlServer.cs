using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Dtos;
using WebApp.Models.Entidades;
using WebApp.Models.Enums;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Repositories;

namespace WebApp.Models.Context;

public class ContextDataSqlServer : IdentityDbContext<Usuario>, IContextData
{
    private readonly SqlConnection? _connection;

    public ContextDataSqlServer(
        IConnectionManager connectionManager,
        DbContextOptions<ContextDataSqlServer> options) : base(options)
    {
        _connection = connectionManager.GetConnection();
    }

    #region Comandos Livro

    public void CadastrarLivro(Livro livro)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO);
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value =
                livro.Id; //seta valor para o parâmetro "@id" no comando SQL
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
            if (_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public List<Livro> ListarLivro()
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
                var idStatusLivro = int.Parse(colunas[4].ToString());

                var livro = new Livro
                    { Id = id, Nome = nome, Autor = autor, Editora = editora, IdStatusLivro = idStatusLivro };
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
            if (_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public Livro ObterLivroPorId(string id)
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
            if (_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public void AtualizarLivro(Livro livro)
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
            if (_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public void ExcluirLivro(string id)
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
            if (_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public void EmprestarLivro(EmprestimoLivro novoEmprestimo)
    {
        try
        {
            _connection!.Open();
            var query = SqlManager.GetSql(TSql.EMPRESTAR_LIVRO);
            var command = new SqlCommand(query, _connection);

            command.Parameters.Add("@idLivro", SqlDbType.VarChar).Value = novoEmprestimo.LivroId;
            command.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = novoEmprestimo.UsuarioId;
            command.Parameters.Add("@dataEmprestimo", SqlDbType.Date).Value = novoEmprestimo.DataEmprestimo.ToString("yyyy-MM-dd");
            command.Parameters.Add("@dataDevolucao", SqlDbType.Date).Value = novoEmprestimo.DataDevolucao.ToString("yyyy-MM-dd");

            command.ExecuteNonQuery();

            _connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Livro> ListarLivrosEmprestados(string idUsuario)
    {
        var livros = new List<Livro>();
        try
        {
            var query = SqlManager.GetSql(TSql.LISTAR_LIVROS_EMPRESTADOS);
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão
            command.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = idUsuario;
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
                var idStatusLivro = int.Parse(colunas[4].ToString());

                var livro = new Livro
                    { Id = id, Nome = nome, Autor = autor, Editora = editora, IdStatusLivro = idStatusLivro };
                livros.Add(livro);
            }

            adapter = null;
            dataset = null;

            return livros;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            if (_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public void DevolverLivro(EmprestimoLivro emprestimoAtualizado)
    {
        try
        {
            _connection!.Open();
            var query = SqlManager.GetSql(TSql.EMPRESTAR_LIVRO);
            var command = new SqlCommand(query, _connection);

            command.Parameters.Add("@idLivro", SqlDbType.VarChar).Value = emprestimoAtualizado.LivroId;
            command.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = emprestimoAtualizado.UsuarioId;
            command.Parameters.Add("@dataEmprestimo", SqlDbType.Date).Value = emprestimoAtualizado.DataEmprestimo.ToString("yyyy-MM-dd");
            command.Parameters.Add("@dataDevolucao", SqlDbType.Date).Value = emprestimoAtualizado.DataDevolucao.ToString("yyyy-MM-dd");

            command.ExecuteNonQuery();

            _connection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public EmprestimoLivro ObterEmprestimoLivro(string idLivro, string idUsuario)
    {
        var emprestimoLivro = new EmprestimoLivro();
        try
        {
            _connection!.Open();
            var query = SqlManager.GetSql(TSql.PESQUISAR_EMPRESTIMO);
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão
            command.Parameters.Add("@idLivro", SqlDbType.VarChar).Value = idLivro;
            command.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = idUsuario;
            var dataset = new DataSet(); //funciona como banco em memória
            var adapter = new SqlDataAdapter(command); //consegue executar comandos para poder capturar os dados
            adapter.Fill(dataset);

            var rows = dataset.Tables[0].Rows; //necessário abrir dataset para acessar linhas e colunas da tabela

            foreach (DataRow item in rows)
            {
                var colunas = item.ItemArray;

                var idEmprestimo = (int)colunas[0];
                var codigoLivro = colunas[1].ToString();
                var codigoUsuario = colunas[2].ToString();
                var dataEmprestimo = colunas[3].ToString();
                var dataDevolucao = colunas[3].ToString();

                emprestimoLivro = new EmprestimoLivro
                {
                    Id = idEmprestimo,
                    LivroId = codigoLivro,
                    UsuarioId = codigoUsuario,
                    DataEmprestimo = DateTime.Parse(dataEmprestimo),
                    DataDevolucao = DateTime.Parse(dataDevolucao)

                };
            }

            adapter = null;
            dataset = null;
            
            _connection.Close(); //fecha conexão com o banco de dados

            return emprestimoLivro;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void InserirDataDevolucaoEfetivaEmprestimo(EmprestimoLivro emprestimoAtualizado)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.ATUALIZAR_EMPRESTIMO);
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@idEmprestimo", SqlDbType.VarChar).Value = emprestimoAtualizado.Id; //seta valor para o parâmetro "@id" no comando SQL
            command.Parameters.Add("@idLivro", SqlDbType.VarChar).Value = emprestimoAtualizado.LivroId;
            command.Parameters.Add("@idUsuario", SqlDbType.VarChar).Value = emprestimoAtualizado.UsuarioId;
            command.Parameters.Add("@dataEmprestimo", SqlDbType.Date).Value = emprestimoAtualizado.DataEmprestimo.ToString("yyyy-MM-dd");
            command.Parameters.Add("@dataDevolucao", SqlDbType.Date).Value = emprestimoAtualizado.DataDevolucao.ToString("yyyy-MM-dd");
            command.Parameters.Add("@dataDevolucaoEfetiva", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
            command.ExecuteNonQuery();
            
            _connection.Close(); //fecha conexão com o banco de dados
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}