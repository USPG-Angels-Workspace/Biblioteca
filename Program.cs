using Biblioteca;
using Biblioteca.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddSingleton<BibliotecarioService>();
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<LibroService>();
builder.Services.AddSingleton<PrestamoService>();

var app = builder.Build();

// dotnet run -- seed: genera datos de ejemplo en Data/ y termina, sin levantar el servidor.
if (args.Contains("seed"))
{
    // BibliotecarioService crea su propio administrador por defecto al construirse.
    app.Services.GetRequiredService<BibliotecarioService>();
    DataSeeder.Sembrar(
        app.Services.GetRequiredService<UsuarioService>(),
        app.Services.GetRequiredService<LibroService>(),
        app.Services.GetRequiredService<PrestamoService>());
    Console.WriteLine("Datos de ejemplo generados en Data/.");
    return;
}

app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cuenta}/{action=Index}/{id?}");

app.Run();
