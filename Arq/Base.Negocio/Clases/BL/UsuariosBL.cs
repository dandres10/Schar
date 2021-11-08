namespace Base.Negocio.Clases.BL
{
    using Base.Datos.Clases.DAL;
    using Base.IC.Acciones.Entidades;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Enumeraciones.Comunes;
    using Base.IC.Transversal;

    public class UsuariosBL : IUsuarioAccion
    {
        private UsuarioDAL usuarioDAL;
        private Respuesta<IUsuariosDTO> respuesta;

        public UsuariosBL()
        {
            this.usuarioDAL = new UsuarioDAL();
            this.respuesta = new Respuesta<IUsuariosDTO>();
        }

        public Respuesta<IUsuariosDTO> ConsultarListaUsuario()
        {
         
            respuesta.Entidades.AddRange(usuarioDAL.ConsultarListaUsuario().Entidades);
            respuesta.Mensajes.Add("Datos consultados correctamente");
            respuesta.TipoNotificacion = TipoNotificacion.Exitoso;

            return respuesta;
        }

        public Respuesta<IUsuariosDTO> EditarUsuario(IUsuariosDTO usuario)
        {
            usuarioDAL.EditarUsuario(usuario);
            return respuesta;
        }

        public Respuesta<IUsuariosDTO> EliminarUsuario(IUsuariosDTO usuario)
        {
            usuarioDAL.EliminarUsuario(usuario);
            return respuesta;
        }

        public Respuesta<IUsuariosDTO> GuardarUsuario(IUsuariosDTO usuario)
        {
            usuarioDAL.GuardarUsuario(usuario);
            return respuesta;
        }
    }
}