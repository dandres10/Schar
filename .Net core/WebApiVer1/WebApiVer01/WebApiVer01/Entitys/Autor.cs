namespace WebApiVer01.Entitys
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Autor
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public List<Libro> Libros { get; set; }
    }
}