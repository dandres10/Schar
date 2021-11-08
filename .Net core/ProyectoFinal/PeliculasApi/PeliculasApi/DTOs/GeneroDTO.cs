namespace PeliculasApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class GeneroDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
    }
}