namespace Business_Layer
{
    using DataAccess;
    using Entity_Layer;
    using System.Collections.Generic;

    public class NegCliente
    {
        public string Actualizar(ClienteBO dto)
        {
            daoCliente dao = new daoCliente();
            return dao.Actualizar(dto);
        }

        public string Eliminar(string dto)
        {
            daoCliente dao = new daoCliente();
            return dao.Eliminar(dto);
        }

        public string Insertar(ClienteBO dto)
        {
            daoCliente dao = new daoCliente();
            return dao.Insertar(dto);
        }

        public List<ClienteBO> Listar()
        {
            daoCliente dao = new daoCliente();
            return dao.Listar();
        }
    }
}