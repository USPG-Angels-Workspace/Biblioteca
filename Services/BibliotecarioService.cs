using System.Text.Json;
using System.Text.Json.Nodes;
using Biblioteca.Models;

namespace Biblioteca.Services;

// Guarda a los bibliotecarios y valida el inicio de sesión.
public class BibliotecarioService
{
    private readonly string rutaArchivo = Path.Combine(AppContext.BaseDirectory, "Data", "bibliotecarios.json");
    private readonly List<Bibliotecario> bibliotecarios = new();

    public BibliotecarioService()
    {
        Cargar();

        // Primera vez que se ejecuta el programa: se crea un bibliotecario por defecto.
        if (bibliotecarios.Count == 0)
        {
            bibliotecarios.Add(new Bibliotecario(1, "Administrador", "0000", "", "admin", "admin123"));
            Guardar();
        }
    }

    public Bibliotecario? ValidarLogin(string nombreUsuario, string contrasena)
    {
        return bibliotecarios.FirstOrDefault(b =>
            b.GetNombreUsuario().Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) &&
            b.GetContrasena() == contrasena);
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
