using System.Data.SqlClient;

namespace WebApp.Models.Interfaces.Repositories;

public interface IConnectionManager
{
    SqlConnection GetConnection();
}