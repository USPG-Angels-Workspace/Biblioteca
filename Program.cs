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

app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cuenta}/{action=Index}/{id?}");

app.Run();
