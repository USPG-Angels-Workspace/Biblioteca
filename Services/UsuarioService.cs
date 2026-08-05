using System.Text.Json;
using System.Text.Json.Nodes;
using Biblioteca.Models;

namespace Biblioteca.Services;

// CRUD de usuarios de la biblioteca, con persistencia en JSON.
public class UsuarioService
{
    private readonly string rutaArchivo;
    private readonly List<Usuario> usuarios = new();

    public UsuarioService(IWebHostEnvironment env)
    {
        rutaArchivo = Path.Combine(env.ContentRootPath, "Data", "usuarios.json");
        Cargar();
    }

    public List<Usuario> Listar()
    {
        return usuarios.ToList();
    }

    public Usuario? BuscarPorId(int id)
    {
        return usuarios.FirstOrDefault(u => u.GetId() == id);
    }

    public Usuario? ValidarLogin(string email, string contrasena)
    {
        return usuarios.FirstOrDefault(u =>
            u.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase) &&
            u.GetContrasena() == contrasena);
    }

    public bool ExisteEmail(string email)
    {
        return usuarios.Any(u => u.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    // Genera el siguiente carnet del año actual: año (2 dígitos) + número
    // consecutivo (5 dígitos, empieza en 00100), ej. 2600100, 2600101...
    public string GenerarSiguienteCarnet()
    {
        var prefijoAnio = DateTime.Now.ToString("yy");

        var siguienteNumero = usuarios
            .Select(u => u.GetIdentificacion())
            .Where(id => id.Length == 7 && id.StartsWith(prefijoAnio))
            .Select(id => int.Parse(id.Substring(2)))
            .DefaultIfEmpty(99)
            .Max() + 1;

        return prefijoAnio + siguienteNumero.ToString("D5");
    }

    public List<Usuario> Buscar(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return Listar();

        return usuarios.Where(u =>
            u.GetNombre().Contains(texto, StringComparison.OrdinalIgnoreCase) ||
            u.GetIdentificacion().Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void Agregar(Usuario usuario)
    {
        usuario.SetId(usuarios.Count == 0 ? 1 : usuarios.Max(u => u.GetId()) + 1);
        usuarios.Add(usuario);
        Guardar();
    }

    public void Editar(Usuario usuario)
    {
        var existente = BuscarPorId(usuario.GetId());
        if (existente == null)
            throw new InvalidOperationException("El usuario no existe.");

        existente.SetNombre(usuario.GetNombre());
        existente.SetIdentificacion(usuario.GetIdentificacion());
        existente.SetEmail(usuario.GetEmail());
        existente.SetContrasena(usuario.GetContrasena());
        existente.SetFechaRegistro(usuario.GetFechaRegistro());
        Guardar();
    }

    public void Eliminar(int id)
    {
        usuarios.RemoveAll(u => u.GetId() == id);
        Guardar();
    }

    private void Cargar()
    {
        if (!File.Exists(rutaArchivo)) return;

        var arreglo = JsonNode.Parse(File.ReadAllText(rutaArchivo))!.AsArray();
        usuarios.Clear();
        foreach (var nodo in arreglo)
        {
            usuarios.Add(new Usuario(
                nodo!["Id"]!.GetValue<int>(),
                nodo!["Nombre"]!.GetValue<string>(),
                nodo!["Identificacion"]!.GetValue<string>(),
                nodo!["Email"]!.GetValue<string>(),
                nodo!["Contrasena"]!.GetValue<string>(),
                nodo!["FechaRegistro"]!.GetValue<DateTime>()));
        }
    }

    private void Guardar()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo)!);
        var arreglo = new JsonArray();
        foreach (var usuario in usuarios)
        {
            arreglo.Add(new JsonObject
            {
                ["Id"] = usuario.GetId(),
                ["Nombre"] = usuario.GetNombre(),
                ["Identificacion"] = usuario.GetIdentificacion(),
                ["Email"] = usuario.GetEmail(),
                ["Contrasena"] = usuario.GetContrasena(),
                ["FechaRegistro"] = usuario.GetFechaRegistro()
            });
        }
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(rutaArchivo, arreglo.ToJsonString(opciones));
    }
}
