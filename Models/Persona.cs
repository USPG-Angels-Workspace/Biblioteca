namespace Biblioteca.Models;

// Clase base para cualquier persona del sistema (Usuario o Bibliotecario).
// Encapsula los datos comunes, incluidas las credenciales de acceso —
// ambas subclases necesitan iniciar sesión, cada una con su propio rol.
public abstract class Persona
{
    private int id;
    private string nombre = string.Empty;
    private string identificacion = string.Empty;
    private string contacto = string.Empty;
    private string nombreUsuario = string.Empty;
    private string contrasena = string.Empty;

    protected Persona(int id, string nombre, string identificacion, string contacto, string nombreUsuario, string contrasena)
    {
        SetId(id);
        SetNombre(nombre);
        SetIdentificacion(identificacion);
        SetContacto(contacto);
        SetNombreUsuario(nombreUsuario);
        SetContrasena(contrasena);
    }

    public int GetId()
    {
        return id;
    }

    public void SetId(int valor)
    {
        id = valor;
    }

    public string GetNombre()
    {
        return nombre;
    }

    public void SetNombre(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("El nombre no puede estar vacío.");
        nombre = valor.Trim();
    }

    public string GetIdentificacion()
    {
        return identificacion;
    }

    public void SetIdentificacion(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("La identificación no puede estar vacía.");
        identificacion = valor.Trim();
    }

    public string GetContacto()
    {
        return contacto;
    }

    public void SetContacto(string valor)
    {
        contacto = valor?.Trim() ?? string.Empty;
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

    // Cada subclase describe su propio rol (polimorfismo).
    public abstract string DescripcionRol();

    public override string ToString()
    {
        return $"{GetNombre()} ({DescripcionRol()})";
    }
}
