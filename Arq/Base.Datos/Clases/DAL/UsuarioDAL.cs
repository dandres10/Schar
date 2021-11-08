namespace Base.Datos.Clases.DAL
{
    using Base.Datos.Contexto;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Enumeraciones.Comunes;
    using Base.IC.Transversal;
    using System.Linq;

    public class UsuarioDAL : IUsuarioAccion
    {
        private Contexto contexto;

        public UsuarioDAL()
        {
            this.contexto = new Contexto();
        }

        public Respuesta<IUsuariosDTO> EditarUsuario(IUsuariosDTO usuario)
        {
            Respuesta<IUsuariosDTO> Respuesta = new Respuesta<IUsuariosDTO>();
            USUARIOS usuarioDO = new USUARIOS
            {
                ID = usuario.ID,
                Apellido = usuario.Apellido,
                Nombre = usuario.Nombre
            };
            contexto.USUARIOS.Attach(usuarioDO);

            return Respuesta;
        }

        public Respuesta<IUsuariosDTO> EliminarUsuario(IUsuariosDTO usuario)
        {
            Respuesta<IUsuariosDTO> Respuesta = new Respuesta<IUsuariosDTO>();
            USUARIOS usuarioDO = new USUARIOS
            {
                ID = usuario.ID,
                Apellido = usuario.Apellido,
                Nombre = usuario.Nombre
            };
            contexto.USUARIOS.Remove(usuarioDO);

            return Respuesta;
        }

        public Respuesta<IUsuariosDTO> GuardarUsuario(IUsuariosDTO usuario)
        {
            Respuesta<IUsuariosDTO> Respuesta = new Respuesta<IUsuariosDTO>();
            USUARIOS usuarioDO = new USUARIOS
            {
                ID = usuario.ID,
                Apellido = usuario.Apellido,
                Nombre = usuario.Nombre
            };
            contexto.USUARIOS.Add(usuarioDO);
            return Respuesta;
        }

        public Respuesta<IUsuariosDTO> ConsultarListaUsuario()
        {
            Respuesta<IUsuariosDTO> Respuesta = new Respuesta<IUsuariosDTO>();
            Respuesta.Entidades.AddRange(Respuesta.Entidades = (from usuario in contexto.USUARIOS select usuario).ToList<IUsuariosDTO>());
            Respuesta.Resultado = true;
            Respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
            Respuesta.Mensajes.Add("Consulta exitosa.");

            return Respuesta;
        }
    }
}