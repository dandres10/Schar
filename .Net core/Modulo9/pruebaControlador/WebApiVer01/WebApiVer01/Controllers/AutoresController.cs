namespace WebApiVer01.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApiVer01.Context;
    using WebApiVer01.Entitys;
    using WebApiVer01.Helpers;
    using WebApiVer01.Models;
    using WebApiVer01.Prueba;
    using WebApiVer01.Services;


    [ApiController]
    [Route("api/[controller]")]

    //[HttpHeaderIsPresent("x-version","1")]
    
    public class AutoresController : ControllerBase
    {

        public AutoresController()
        {

        }

        private readonly ApplicacionDbContext context;
       
        private readonly ILogger<AutoresController> logger;
        private readonly IMapper mapper;
        private readonly IRepositorioAutores repositorioAutores;

        public AutoresController(ApplicacionDbContext context, IRepositorioAutores  repositorioAutores)
        {
            this.context = context;
            
           
            this.repositorioAutores = repositorioAutores;
        }

        
        [HttpGet("{id}", Name = "ObtenerAutor")]
        public  ActionResult<Autor> Get(int id)
        {
            var autor = repositorioAutores.ObtenerPorId(id);
            if (autor == null)
            {
                return NotFound();
            }

           

            //GenerarEnlaces(autorDTO);

            return autor;
        }

        
    }
}