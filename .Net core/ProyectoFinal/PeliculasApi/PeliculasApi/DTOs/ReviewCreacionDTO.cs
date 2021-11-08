namespace PeliculasApi.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReviewCreacionDTO
    {
        public string Comentario { get; set; }

        [Range(1, 5)]
        public int Puntuacion { get; set; }
    }
}