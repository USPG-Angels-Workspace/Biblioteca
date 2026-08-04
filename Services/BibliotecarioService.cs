using System.Text.Json;
using System.Text.Json.Nodes;
using Biblioteca.Models;

namespace Biblioteca.Services;

// CRUD de empleados (bibliotecarios) y validación del inicio de sesión.
public class BibliotecarioService
{
    private readonly string rutaArchivo;
    private readonly List<Bibliotecario> bibliotecarios = new();

    public BibliotecarioService(IWebHostEnvironment env)
    {
        rutaArchivo = Path.Combine(env.ContentRootPath, "Data", "bibliotecarios.json");
        Cargar();

        // Primera vez que se ejecuta el programa: se crea un bibliotecario por defecto.
        if (bibliotecarios.Count == 0)
        {
            bibliotecarios.Add(new Bibliotecario(1, "Administrador", "0000", "", "admin", "admin123"));
            Guardar();
        }
    }

    public List<Bibliotecario> Listar()
    {
        return bibliotecarios.ToList();
    }

    public Bibliotecario? BuscarPorId(int id)
    {
        return bibliotecarios.FirstOrDefault(b => b.GetId() == id);
    }

    public Bibliotecario? ValidarLogin(string nombreUsuario, string contrasena)
    {
        return bibliotecarios.FirstOrDefault(b =>
            b.GetNombreUsuario().Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) &&
            b.GetContrasena() == contrasena);
    }

    public void Agregar(Bibliotecario bibliotecario)
    {
        bibliotecario.SetId(bibliotecarios.Count == 0 ? 1 : bibliotecarios.Max(b => b.GetId()) + 1);
        bibliotecarios.Add(bibliotecario);
        Guardar();
    }

    public void Editar(Bibliotecario bibliotecario)
    {
        var existente = BuscarPorId(bibliotecario.GetId());
        if (existente == null)
            throw new InvalidOperationException("El empleado no existe.");

        existente.SetNombre(bibliotecario.GetNombre());
        existente.SetIdentificacion(bibliotecario.GetIdentificacion());
        existente.SetContacto(bibliotecario.GetContacto());
        existente.SetNombreUsuario(bibliotecario.GetNombreUsuario());
        existente.SetContrasena(bibliotecario.GetContrasena());
        Guardar();
    }

    public void Eliminar(int id)
    {
        bibliotecarios.RemoveAll(b => b.GetId() == id);
        Guardar();
    }

    private void Cargar()
    {
        if (!File.Exists(rutaArchivo)) return;

        var arreglo = JsonNode.Parse(File.ReadAllText(rutaArchivo))!.AsArray();
        bibliotecarios.Clear();
        foreach (var nodo in arreglo)
        {
            bibliotecarios.Add(new Bibliotecario(
                nodo!["Id"]!.GetValue<int>(),
                nodo!["Nombre"]!.GetValue<string>(),
                nodo!["Identificacion"]!.GetValue<string>(),
                nodo!["Contacto"]!.GetValue<string>(),
                nodo!["NombreUsuario"]!.GetValue<string>(),
                nodo!["Contrasena"]!.GetValue<string>()));
        }
    }

    private void Guardar()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo)!);
        var arreglo = new JsonArray();
        foreach (var bibliotecario in bibliotecarios)
        {
            arreglo.Add(new JsonObject
            {
                ["Id"] = bibliotecario.GetId(),
                ["Nombre"] = bibliotecario.GetNombre(),
                ["Identificacion"] = bibliotecario.GetIdentificacion(),
                ["Contacto"] = bibliotecario.GetContacto(),
                ["NombreUsuario"] = bibliotecario.GetNombreUsuario(),
                ["Contrasena"] = bibliotecario.GetContrasena()
            });
        }
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(rutaArchivo, arreglo.ToJsonString(opciones));
    }
}
