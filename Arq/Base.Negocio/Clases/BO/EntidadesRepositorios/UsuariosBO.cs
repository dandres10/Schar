

namespace Base.Negocio.Clases.BO.EntidadesRepositorios
{
    using Base.IC.DTO.EntidadesRepositorio;


    public class UsuariosBO : IUsuariosDTO
    {
        public int ID { get ; set ; }
        public string Nombre { get ; set ; }
        public string Apellido { get ; set ; }
    }
}
