using System.ComponentModel.DataAnnotations;

namespace MiPrimerWebApiM3.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
    }
}