using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApp.Models.Context;
using WebApp.Models.Entidades;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Interfaces.Services;
using WebApp.Models.Repositories;
using WebApp.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

AdicionarDependenciasRepositories(builder.Services);
AdicionarDependenciasServices(builder.Services);
AdicionarIdentity(builder.Services);
ConfigureDataSource(builder.Services);

void AdicionarIdentity(IServiceCollection services)
{
    services.AddHttpContextAccessor();
    services
        .AddIdentityCore<Usuario>(options => { options.User.RequireUniqueEmail = false; })
        .AddUserStore<CustomUserStore>()
        .AddDefaultTokenProviders();
    services.AddScoped<SignInManager<Usuario>>();
    services.AddScoped<UserManager<Usuario>>();
}

void AdicionarDependenciasRepositories(IServiceCollection services)
{
    services.TryAddScoped<ILivroRepository, LivroRepository>();
    services.TryAddScoped<IClienteRepository, ClienteRepository>();
    services.TryAddScoped<IUsuarioRepository, UsuarioRepository>();
}

void AdicionarDependenciasServices(IServiceCollection services)
{
    services.TryAddScoped<ILivroService, LivroService>();
    services.TryAddScoped<IClienteService, ClienteService>();
    services.TryAddScoped<IUsuarioService, UsuarioService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
return;

void ConfigureDataSource(IServiceCollection services)
{
    var dataSource = builder.Configuration["DataSource"];

    switch (dataSource)
    {
        case "Local":
            services.TryAddScoped<IContextData, ContextDataFake>();
            break;
        case "SqlServer":
            services.AddDbContext<ContextDataSqlServer>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaJoia")));
            services.TryAddScoped<IContextData, ContextDataSqlServer>();
            services.TryAddScoped<IConnectionManager, ConnectionManager>();
            break;
    }
}