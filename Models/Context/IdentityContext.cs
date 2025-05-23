using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entidades;

namespace WebApp.Models.Context;

public class IdentityContext : IdentityDbContext<Usuario>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }
   
    public DbSet<Usuario> Usuarios { get; set; }
}