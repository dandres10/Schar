namespace MiPrimerWebApiM3.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using MiPrimerWebApiM3.Contexts;
    using MiPrimerWebApiM3.Entities;
    using MiPrimerWebApiM3.Helpers;
    using MiPrimerWebApiM3.Models;
    using MiPrimerWebApiM3.Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ClaseB claseB;
        private readonly ILogger<AutoresController> logger;
        private readonly IMapper mapper;


        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Autor> jsonPatchDocument)
        {
            if (jsonPatchDocument == null)
            {
                return BadRequest();
            }

            var autorDeLaDB = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autorDeLaDB == null)
            {
                return NotFound();
            }

            jsonPatchDocument.ApplyTo(autorDeLaDB, ModelState);
            var isValid = TryValidateModel(autorDeLaDB);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            await context.SaveChangesAsync();

            return NoContent();
        }

        public AutoresController(ApplicationDbContext context, ClaseB claseB, ILogger<AutoresController> logger, IMapper mapper)
        {
            this.context = context;
            this.claseB = claseB;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ServiceFilter(typeof(MiFiltroDeAccion))]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> Get()
        {
            var autores = await context.Autores.ToListAsync();
            //throw new NotImplementedException();
            logger.LogInformation("Obteniendo los autores");
            claseB.HacerAlgo();
            var autotesDto = mapper.Map<List<AutorDTO>>(autores);
            return autotesDto;
        }

        //[HttpGet("/primer")]
        [HttpGet]
        [Route("/primer")]
        public ActionResult<Autor> GetPrimerAutor()
        {
            return context.Autores.FirstOrDefault();
        }

        //[HttpGet("{id}/{param2?}", Name = "ObtenerAutor")]  valor opcional
        [HttpGet("{id}/{param2=Leon}", Name = "ObtenerAutor")] //valor por defecto en  la ruta
        public async Task<ActionResult<AutorDTO>> Get(int id, [BindRequired]string param2)
        {
            Autor autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                logger.LogWarning($"El autor de id {id} no ha sido encontrado");
                return NotFound();
            }

            var autorDTO = mapper.Map<AutorDTO>(autor);

            return autorDTO;
        }

        

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            //TryValidateModel(autor); // volver a validar el modelo que llega
            context.Autores.Add(autor);
            context.SaveChanges();
            var autorDTO = mapper.Map<AutorDTO>(autor);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autorDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }
    }
}