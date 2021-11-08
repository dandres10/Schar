using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVer01.Context;
using WebApiVer01.Entitys;

namespace WebApiVer01.Prueba
{
    public class RepositorioAutores : IRepositorioAutores
    {
        private readonly ApplicacionDbContext context;

        public RepositorioAutores(ApplicacionDbContext context)
        {
            this.context = context;
        }
        public Autor ObtenerPorId(int id)
        {
            return context.Autores.FirstOrDefault(x => x.Id == id);
        }
    }
}
