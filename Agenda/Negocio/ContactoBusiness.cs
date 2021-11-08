using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class ContactoBusiness
    {
        AgendaLinqDataContext data = new AgendaLinqDataContext();

        public List<ContactosTBEntity> ConsultarContactos()
        {
            //DataTable ListaContactos = new DataTable();
            //ListaContactos = this.ConvertToDataTable(data.ContactosTB.ToList());
            //return ListaContactos;

            List<ContactosTBEntity> lstContactos = new List<ContactosTBEntity>();
            foreach (ContactosTB item in data.ContactosTB.ToList())
            {
                ContactosTBEntity objContactos = new ContactosTBEntity();
                objContactos.id = item.id;
                objContactos.nombre = item.nombre;
                objContactos.apellido = item.apellido;
                objContactos.telefono = item.telefono;
                objContactos.correo = item.correo;
                lstContactos.Add(objContactos);

            }
            return lstContactos;
        }


        public string InsertarContacto(ContactosTBEntity pObjContacto)
        {
            try
            {
                ContactosTB objContactoInsertar = new ContactosTB();
                objContactoInsertar.nombre = pObjContacto.nombre;
                objContactoInsertar.apellido = pObjContacto.apellido;
                objContactoInsertar.telefono = pObjContacto.telefono;
                objContactoInsertar.correo = pObjContacto.correo;

                data.ContactosTB.InsertOnSubmit(objContactoInsertar);
                data.SubmitChanges();
                return "Se ha insertado el contacto";
            }
            catch (Exception e)
            {
                return "Error vuelva a intentarlo mas tarde"+ e.Message;
                
            }
        }


        public string EliminarContacto(int pId)
        {
            try
            {
                ContactosTB objContactoEliminar = data.ContactosTB.Single(x => x.id == pId);
                data.ContactosTB.DeleteOnSubmit(objContactoEliminar);
                data.SubmitChanges();
                return "Se elimino con exito";

            }
            catch (Exception e)
            {

                return "no se pudo eliminar " + e.Message;
            }
        }

        public ContactosTBEntity ConsultarUnContacto(int pId)
        {
            
                ContactosTB objContactoConsulta = data.ContactosTB.Single(x => x.id == pId);
                ContactosTBEntity objContactoDevolver = new ContactosTBEntity();
                objContactoDevolver.id = objContactoConsulta.id;
                objContactoDevolver.nombre = objContactoConsulta.nombre;
                objContactoDevolver.apellido = objContactoConsulta.apellido;
                objContactoDevolver.telefono = objContactoConsulta.telefono;
                objContactoDevolver.correo = objContactoConsulta.correo;

                return objContactoDevolver;
            
            

        }


        public string EditarContacto(ContactosTBEntity pObjContacto)
        {

            try
            {
                ContactosTB objContactoConsulta = data.ContactosTB.Single(x => x.id == pObjContacto.id);

                objContactoConsulta.nombre = pObjContacto.nombre;
                objContactoConsulta.apellido = pObjContacto.apellido;
                objContactoConsulta.telefono = pObjContacto.telefono;
                objContactoConsulta.correo = pObjContacto.correo;
                                data.SubmitChanges();

                return "Se actualizo el contacto";
            }
            catch (Exception e)
            {
                return "No se pudo actualizar el contacto"+e.Message;
                
            }
        }



        



        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }











    }
}
