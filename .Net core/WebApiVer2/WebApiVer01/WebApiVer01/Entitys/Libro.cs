namespace WebApiVer01.Entitys
{
    using System.ComponentModel.DataAnnotations;

    public class Libro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public int AutorId { get; set; }

       
    }
}