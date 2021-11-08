namespace DataAccess.Contract
{
    using System.Collections.Generic;

    public interface IOperacionesCrud<T>
    {
        string Insertar(T dto);

        string Actualizar(T dto);

        string Eliminar(string dto);

        List<T> Listar();
    }
}