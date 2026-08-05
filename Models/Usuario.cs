using System.Text.RegularExpressions;

namespace Biblioteca.Models;

// Usuario (socio) que puede pedir préstamos en la biblioteca. Hereda los
// datos personales comunes de Persona y solo agrega lo que le es propio.
public class Usuario : Persona
{
    private DateTime fechaRegistro;

    public Usuario(int id, string nombre, string identificacion, string email,
        string contrasena, DateTime fechaRegistro)
        : base(id, nombre, identificacion, email, contrasena)
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

    // Un usuario se identifica con su carnet de estudiante: año (2 dígitos)
    // + número (5 dígitos), ej. 2600100. Refuerza la validación de Persona.
    public override void SetIdentificacion(string valor)
    {
        base.SetIdentificacion(valor);
        if (!Regex.IsMatch(GetIdentificacion(), @"^\d{7}$"))
            throw new ArgumentException("El carnet debe tener el formato año + número (7 dígitos), ej. 2600100.");
    }

    public override string DescripcionRol()
    {
        return "Usuario de biblioteca";
    }
}
