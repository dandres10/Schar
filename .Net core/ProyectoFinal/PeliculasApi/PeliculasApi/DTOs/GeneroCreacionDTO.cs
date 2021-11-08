namespace PeliculasApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
    }
}