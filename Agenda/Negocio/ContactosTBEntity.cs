using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ContactosTBEntity
    {

        public ContactosTBEntity()
        {

        }

        public ContactosTBEntity(string pNombre,string pApellido, string pTelefono, string pCorreo,int? pId = null)
        {
            nombre = pNombre;
            apellido = pApellido;
            telefono = pTelefono;
            correo = pCorreo;

            if(pId != null)
            {
                id = pId;
            }
        }

        public int? id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }

    }
}
