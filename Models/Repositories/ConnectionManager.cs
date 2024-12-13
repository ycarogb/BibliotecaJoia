using System.Data.SqlClient;
using WebApp.Models.Interfaces.Repositories;

namespace WebApp.Models.Repositories;

public class ConnectionManager : IConnectionManager
{
    private readonly IConfiguration _configuration;

    public ConnectionManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public SqlConnection GetConnection()
    {
        var connectionString = _configuration.GetConnectionString("BibliotecaJoia");
        var connection = new SqlConnection(connectionString);

        return connection;
    }
}