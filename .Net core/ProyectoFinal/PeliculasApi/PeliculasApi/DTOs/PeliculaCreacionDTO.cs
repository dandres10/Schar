namespace PeliculasApi.DTOs
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PeliculasApi.Helpers;
    using PeliculasApi.Validaciones;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PeliculaCreacionDTO 
    {
        [Required]
        [StringLength(300)]
        public string Titulo { get; set; }

        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }

        [PesoArchivoValidacion(PesoMaximoEnMEgaBytes: 4)]
        [TipoArchivoValidacion(GrupoTipoArchivo.Imagen)]
        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenerosIDs { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorPeliculasCreacionDTO>>))]
        public List<ActorPeliculasCreacionDTO> Actores { get; set; }
    }
}