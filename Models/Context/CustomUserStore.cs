using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entidades;

namespace WebApp.Models.Context;

public class CustomUserStore : IUserPasswordStore<Usuario>
{
    private readonly IConfiguration _configuration;

    public CustomUserStore(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_configuration.GetConnectionString("BibliotecaJoia"));
    }

    public Task<string> GetUserIdAsync(Usuario user, CancellationToken cancellationToken)
        => Task.FromResult(user.Id);

    public Task<string> GetUserNameAsync(Usuario user, CancellationToken cancellationToken)
        => Task.FromResult(user.UserName);

    public Task SetUserNameAsync(Usuario user, string userName, CancellationToken cancellationToken)
    {
        user.UserName = userName;
        return Task.CompletedTask;
    }

    public Task<string> GetNormalizedUserNameAsync(Usuario user, CancellationToken cancellationToken)
        => Task.FromResult(user.NormalizedUserName);

    public Task SetNormalizedUserNameAsync(Usuario user, string normalizedName, CancellationToken cancellationToken)
    {
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask;
    }

    public async Task<IdentityResult> CreateAsync(Usuario user, CancellationToken cancellationToken)
    {
        using var conn = GetConnection();
        await conn.OpenAsync(cancellationToken);

        var cmd = new SqlCommand("INSERT INTO Usuario (Id, UserName, NormalizedUserName, Email, PasswordHash) VALUES (@Id, @UserName, @NormalizedUserName, @Email, @PasswordHash)", conn);
        cmd.Parameters.AddWithValue("@Id", user.Id);
        cmd.Parameters.AddWithValue("@UserName", user.UserName);
        cmd.Parameters.AddWithValue("@NormalizedUserName", user.NormalizedUserName);
        cmd.Parameters.AddWithValue("@Email", user.Email);
        cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);

        await cmd.ExecuteNonQueryAsync(cancellationToken);

        return IdentityResult.Success;
    }

    public Task<IdentityResult> DeleteAsync(Usuario user, CancellationToken cancellationToken)
        => Task.FromResult(IdentityResult.Success); // Implemente conforme necessário

    public async Task<Usuario?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        using var conn = GetConnection();
        cancellationToken = CancellationToken.None;
        await conn.OpenAsync(cancellationToken);

        var cmd = new SqlCommand("SELECT Id, UserName, NormalizedUserName, Email, PasswordHash FROM Usuario WHERE NormalizedUserName = @NormalizedUserName", conn);
        cmd.Parameters.AddWithValue("@NormalizedUserName", normalizedUserName);

        using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
        if (await reader.ReadAsync(cancellationToken))
        {
            return new Usuario
            {
                Id = reader.GetString(0),
                UserName = reader.GetString(1),
                NormalizedUserName = reader.GetString(2),
                Email = reader.GetString(3),
                PasswordHash = reader.GetString(4)
            };
        }

        return null;
    }

    public Task<Usuario?> FindByIdAsync(string userId, CancellationToken cancellationToken)
        => Task.FromResult<Usuario?>(null); // Implemente se quiser

    public Task<IdentityResult> UpdateAsync(Usuario user, CancellationToken cancellationToken)
        => Task.FromResult(IdentityResult.Success); // Implemente se quiser

    public Task SetPasswordHashAsync(Usuario user, string passwordHash, CancellationToken cancellationToken)
    {
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string> GetPasswordHashAsync(Usuario user, CancellationToken cancellationToken)
        => Task.FromResult(user.PasswordHash);

    public Task<bool> HasPasswordAsync(Usuario user, CancellationToken cancellationToken)
        => Task.FromResult(user.PasswordHash != null);

    public void Dispose() { }
}