namespace Base.IC.Clases
{
    using Base.IC.Enumeraciones.Comunes;
    using System.Collections.Generic;

    public interface IRespuesta<T>
    {
        bool Resultado { get; set; }
        List<T> Entidades { get; set; }
        List<string> Mensajes { get; set; }
        TipoNotificacion TipoNotificacion { get; set; }
    }
}