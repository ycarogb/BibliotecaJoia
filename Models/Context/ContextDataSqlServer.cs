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
    public void CadastrarLivro(Livro livro)
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
            if(_connection is { State: ConnectionState.Connecting })
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
            if(_connection is { State: ConnectionState.Connecting })
                _connection.Close(); //fecha conexão com o banco de dados
        }
    }

    public void CadastrarCliente(Cliente cliente)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.CADASTRAR_CLIENTE); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id; //seta valor para o parâmetro "@id" no comando SQL
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
            command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.Cpf;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
            command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = cliente.Telefone;
            command.Parameters.Add("@idStatusCliente", SqlDbType.Int).Value = cliente.IdStatusCliente;
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

    public List<Cliente> ListarCliente()
    {
        var clientes = new List<Cliente>();
        try
        {
            var query = SqlManager.GetSql(TSql.LISTAR_CLIENTES); 
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
                var cpf = colunas[2].ToString();
                var email = colunas[3].ToString();
                var telefone = colunas[4].ToString();
                var idStatusCliente = (int)colunas[5];

                var cliente = new Cliente() { Id = id, Nome = nome, Telefone = telefone, Cpf = cpf, Email = email, IdStatusCliente = idStatusCliente, Status = (StatusCliente)idStatusCliente};
                clientes.Add(cliente);
            }

            adapter = null;
            dataset = null;

            return clientes;
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

    public Cliente ObterClientePorId(string id)
    {
        Cliente cliente = null;
        try
        {
            var query = SqlManager.GetSql(TSql.PESQUISAR_CLIENTE); 
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
                var cpf = colunas[2].ToString();
                var email = colunas[3].ToString();
                var telefone = colunas[4].ToString();
                var idStatusCliente = (int)colunas[5];

                cliente = new Cliente { Id = codigo, Nome = nome, Telefone = telefone, Cpf = cpf, Email = email, IdStatusCliente = idStatusCliente, Status = (StatusCliente)idStatusCliente };
            }

            adapter = null;
            dataset = null;

            return cliente;
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

    public void AtualizarCliente(Cliente cliente)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.ATUALIZAR_CLIENTE); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id; //seta valor para o parâmetro "@id" no comando SQL
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
            command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = cliente.Telefone;
            command.Parameters.Add("@idStatusCliente", SqlDbType.Int).Value = cliente.IdStatusCliente;
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

    public void ExcluirCliente(string id)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.EXCLUIR_CLIENTE); 
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

    public void CadastrarUsuario(Usuario usuario)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.CADASTRAR_USUARIO); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = usuario.Id; //seta valor para o parâmetro "@id" no comando SQL
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
            command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;
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

    public List<Usuario> ListarUsuarios()
    {
        var usuarios = new List<Usuario>();
        try
        {
            var query = SqlManager.GetSql(TSql.LISTAR_USUARIOS); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão
            var dataset = new DataSet(); //funciona como banco em memória
            var adapter = new SqlDataAdapter(command); //consegue executar comandos para poder capturar os dados
            adapter.Fill(dataset);

            var rows = dataset.Tables[0].Rows; //necessário abrir dataset para acessar linhas e colunas da tabela

            foreach (DataRow item in rows)
            {
                var colunas = item.ItemArray;

                var id = (int)colunas[0];
                var login = colunas[1].ToString();
                var senha = colunas[2].ToString();

                var usuario = new Usuario { Id = id, Login = login, Senha = senha};
                usuarios.Add(usuario);
            }

            adapter = null;
            dataset = null;

            return usuarios;
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

    public Usuario ObterUsuarioPorId(int id)
    {
        var usuario = new Usuario();
        try
        {
            var query = SqlManager.GetSql(TSql.PESQUISAR_USUARIO); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            var dataset = new DataSet(); //funciona como banco em memória
            var adapter = new SqlDataAdapter(command); //consegue executar comandos para poder capturar os dados
            adapter.Fill(dataset);

            var rows = dataset.Tables[0].Rows; //necessário abrir dataset para acessar linhas e colunas da tabela

            foreach (DataRow item in rows)
            {
                var colunas = item.ItemArray;
                var codigo = (int)colunas[0];
                var login = colunas[1].ToString();
                var senha = colunas[2].ToString();

                usuario = new Usuario
                {
                    Id = codigo, Login = login, Senha = senha
                };
            }

            adapter = null;
            dataset = null;

            return usuario;
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
    
    public void AtualizarUsuario(Usuario usuario)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.ATUALIZAR_USUARIO); 
            var command = new SqlCommand(query, _connection); //cria um comando SQL a partir da query e da conexão

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = usuario.Id; //seta valor para o parâmetro "@id" no comando SQL
            command.Parameters.Add("@nome", SqlDbType.VarChar).Value = usuario.Login;
            command.Parameters.Add("@autor", SqlDbType.VarChar).Value = usuario.Senha;
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

    public void ExcluirUsuario(int id)
    {
        try
        {
            _connection!.Open(); //abre conexão com o banco de dados

            var query = SqlManager.GetSql(TSql.EXCLUIR_USUARIO); 
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