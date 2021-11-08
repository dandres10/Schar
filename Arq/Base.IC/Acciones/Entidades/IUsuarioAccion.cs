namespace Base.IC.Acciones.Entidades
{
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Transversal;

    public interface IUsuarioAccion
    {
        Respuesta<IUsuariosDTO> GuardarUsuario(IUsuariosDTO usuario);

        Respuesta<IUsuariosDTO> EditarUsuario(IUsuariosDTO usuario);

        Respuesta<IUsuariosDTO> ConsultarListaUsuario();

        Respuesta<IUsuariosDTO> EliminarUsuario(IUsuariosDTO usuario);
    }
}