namespace PeliculasApi.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using PeliculasApi.DTOs;
    using PeliculasApi.Entidades;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/generos")]
    public class GenerosController : CustomBaseController
    {
        public GenerosController(ApplicacionDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            return await Get<Genero, GeneroDTO>();
            //return mapper.Map<List<GeneroDTO>>(await context.Generos.ToListAsync());
        }

        [HttpGet("{id:int}", Name = "obtenerGenero")]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            return await Get<Genero, GeneroDTO>(id);

            //var entidad = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            //if (entidad == null)
            //{
            //    return NotFound();
            //}

            //return mapper.Map<GeneroDTO>(entidad);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            return await Post<GeneroCreacionDTO, Genero, GeneroDTO>(generoCreacionDTO, "obtenerGenero");
            //var entidad = mapper.Map<Genero>(generoCreacionDTO);
            //context.Add(entidad);
            //await context.SaveChangesAsync();
            //var generoDTO = mapper.Map<GeneroDTO>(entidad);
            //return new CreatedAtRouteResult("obtenerGenero", new { id = generoDTO.Id }, generoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            return await Put<GeneroCreacionDTO, Genero>(id, generoCreacionDTO);
            //var entidad = mapper.Map<Genero>(generoCreacionDTO);
            //entidad.Id = id;
            //context.Entry(entidad).State = EntityState.Modified;
            //await context.SaveChangesAsync();
            //return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Genero>(id);
            //var existe = await context.Generos.AnyAsync(x => x.Id == id);
            //if (!existe)
            //{
            //    return NotFound();
            //}

            //context.Remove(new Genero() { Id = id });
            //await context.SaveChangesAsync();
            //return NoContent();
        }
    }
}