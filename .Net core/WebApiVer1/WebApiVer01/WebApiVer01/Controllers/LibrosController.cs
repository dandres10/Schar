﻿namespace WebApiVer01.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using WebApiVer01.Context;
    using WebApiVer01.Entitys;

    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicacionDbContext context;

        public LibrosController(ApplicacionDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.Include(x => x.Autor).ToList();
        }

        [HttpGet("{id}", Name = "ObtenerLibro")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = context.Libros.Include(x => x.Autor).FirstOrDefault(x => x.Id == id);
            if (libro == null)
            {
                return NotFound();
            }
            return libro;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Libro libro)
        {
            context.Libros.Add(libro);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerLibro", new { id = libro.Id }, libro);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro value)
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
        public ActionResult<Libro> Delete(int id)
        {

            var libro = context.Libros.FirstOrDefault(x => x.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(libro);
            context.SaveChanges();
            return libro;

        }
    }
}