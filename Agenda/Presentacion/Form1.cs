using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {

        ContactoBusiness objContactos = new ContactoBusiness();

        public Form1()
        {
            InitializeComponent();
            CargarContactos();
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }

        

        public void CargarContactos()
        {
            
            dataGridView1.DataSource = objContactos.ConsultarContactos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string rta = objContactos.InsertarContacto(new ContactosTBEntity(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtCorreo.Text));
            MessageBox.Show(rta);
            Limpiar();
            CargarContactos();
        }

        public void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            ContactosTBEntity objContactoConsultado = objContactos.ConsultarUnContacto(id);
            txtId.Text = objContactoConsultado.id.ToString();
            txtNombre.Text = objContactoConsultado.nombre.ToString();
            txtApellido.Text = objContactoConsultado.apellido.ToString();
            txtTelefono.Text = objContactoConsultado.telefono.ToString();
            txtCorreo.Text = objContactoConsultado.correo.ToString();
            btnCrear.Visible = false;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
        }

        public void EliminarContacto(int pId)
        {
            MessageBox.Show(objContactos.EliminarContacto(pId));
            CargarContactos();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(objContactos.EliminarContacto(int.Parse(txtId.Text)));
            CargarContactos();
            btnCrear.Visible = !false;
            btnEditar.Visible = !true;
            btnEliminar.Visible = !true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ContactosTBEntity objContactoEditar = new ContactosTBEntity(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtCorreo.Text,int.Parse(txtId.Text) );
            MessageBox.Show(objContactos.EditarContacto(objContactoEditar));
            CargarContactos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
