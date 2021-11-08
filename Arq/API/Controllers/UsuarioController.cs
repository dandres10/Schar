namespace API.Controllers
{
    using API.Models;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Enumeraciones.Comunes;
    using Base.IC.Transversal;
    using Base.Negocio.Clases.BL;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/Usuario")]
    public class UsuarioController
    {
        private UsuariosBL negocioUsuario;

        public UsuarioController()
        {
            negocioUsuario = new UsuariosBL();
        }

        [HttpPost]
        [Route("ConsultarListaUsuario")]
        public Respuesta<Usuarios> ConsultarListaUsuario()
        {
            Respuesta<Usuarios> respuesta = new Respuesta<Usuarios>();
            List<Usuarios> onjetosMapeados = new List<Usuarios>();
            var usuarios = negocioUsuario.ConsultarListaUsuario();

            foreach (IUsuariosDTO usuario in usuarios.Entidades)
            {
                Usuarios usuariosDO = new Usuarios
                {
                    ID = usuario.ID,
                    Apellido = usuario.Apellido,
                    Nombre = usuario.Nombre
                };
                onjetosMapeados.Add(usuariosDO);
            }

            respuesta.Entidades.AddRange(onjetosMapeados);
            respuesta.TipoNotificacion = TipoNotificacion.Exitoso;
            respuesta.Resultado = true;
            respuesta.Mensajes.Add("Consulta exitosa.");

            return respuesta;
        }
    }
}