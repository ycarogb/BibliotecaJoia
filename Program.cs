using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApp.Models.Context;
using WebApp.Models.Interfaces.Repositories;
using WebApp.Models.Interfaces.Services;
using WebApp.Models.Repositories;
using WebApp.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.TryAddScoped<ILivroRepository, LivroRepository>();
builder.Services.TryAddScoped<ILivroService, LivroService>();
ConfigureDataSource(builder.Services);

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
            services.TryAddScoped<IContextData, ContextDataSqlServer>();
            builder.Services.TryAddScoped<IConnectionManager, ConnectionManager>();
            break;
    }
}