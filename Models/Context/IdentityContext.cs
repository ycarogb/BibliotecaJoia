using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entidades;

namespace WebApp.Models.Context;

public class IdentityContext : IdentityDbContext<Usuario>
{
    public IdentityContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
        
    }
    
}