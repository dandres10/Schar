namespace Base.Datos.Contexto
{
    using System.ComponentModel.DataAnnotations;

    public partial class USUARIOS
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Apellido { get; set; }
    }
}