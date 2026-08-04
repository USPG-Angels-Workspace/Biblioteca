namespace Biblioteca.Models;

// Clase base para cualquier persona del sistema (Usuario o Bibliotecario).
// Encapsula los datos comunes y valida que nunca queden vacíos.
public abstract class Persona
{
    private int id;
    private string nombre = string.Empty;
    private string identificacion = string.Empty;
    private string contacto = string.Empty;

    protected Persona(int id, string nombre, string identificacion, string contacto)
    {
        SetId(id);
        SetNombre(nombre);
        SetIdentificacion(identificacion);
        SetContacto(contacto);
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

    // Cada subclase describe su propio rol (polimorfismo).
    public abstract string DescripcionRol();

    public override string ToString()
    {
        return $"{GetNombre()} ({DescripcionRol()})";
    }
}
