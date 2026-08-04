namespace Biblioteca.Models;

// Bibliotecario que administra el sistema. Hereda de Persona y agrega
// las credenciales que usa para iniciar sesión.
public class Bibliotecario : Persona
{
    private string nombreUsuario = string.Empty;
    private string contrasena = string.Empty;

    public Bibliotecario(int id, string nombre, string identificacion, string contacto,
        string nombreUsuario, string contrasena)
        : base(id, nombre, identificacion, contacto)
    {
        SetNombreUsuario(nombreUsuario);
        SetContrasena(contrasena);
    }

    public string GetNombreUsuario()
    {
        return nombreUsuario;
    }

    public void SetNombreUsuario(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("El nombre de usuario no puede estar vacío.");
        nombreUsuario = valor.Trim();
    }

    public string GetContrasena()
    {
        return contrasena;
    }

    public void SetContrasena(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("La contraseña no puede estar vacía.");
        contrasena = valor;
    }

    public override string DescripcionRol()
    {
        return "Bibliotecario";
    }
}
