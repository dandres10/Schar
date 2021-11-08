namespace PeliculasApi.DTOs
{
    using Microsoft.AspNetCore.Http;
    using PeliculasApi.Validaciones;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ActorCreacionDTO
    {
        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [PesoArchivoValidacion(PesoMaximoEnMEgaBytes: 4)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Imagen)]
        public IFormFile Foto { get; set; }
    }
}