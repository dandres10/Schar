namespace Base.IC.Transversal
{
    using Base.IC.Clases;
    using Base.IC.Enumeraciones.Comunes;
    using System.Collections.Generic;

    public class Respuesta<T> : IRespuesta<T>
    {
        public bool Resultado { get ; set ; }
        public List<T> Entidades { get ; set ; }
        public List<string> Mensajes { get ; set ; }
        public TipoNotificacion TipoNotificacion { get ; set ; }
    }
}