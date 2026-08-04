namespace Biblioteca.Models;

// Usuario que puede pedir préstamos en la biblioteca. Hereda los datos
// personales comunes de Persona y solo agrega lo que le es propio.
public class Usuario : Persona
{
    private DateTime fechaRegistro;

    public Usuario(int id, string nombre, string identificacion, string contacto, DateTime fechaRegistro)
        : base(id, nombre, identificacion, contacto)
    {
        SetFechaRegistro(fechaRegistro);
    }

    public DateTime GetFechaRegistro()
    {
        return fechaRegistro;
    }

    public void SetFechaRegistro(DateTime valor)
    {
        fechaRegistro = valor;
    }

    public override string DescripcionRol()
    {
        return "Usuario de biblioteca";
    }
}
