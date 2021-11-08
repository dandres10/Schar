using WebApiVer01.Entitys;

namespace WebApiVer01.Prueba
{
    public interface IRepositorioAutores
    {
        Autor ObtenerPorId(int id);
    }
}