using Consultas.DTO;
using Consultas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private AdventureWorks2019Context _adventureWorks2019Context;

        public WeatherForecastController()
        {
            _adventureWorks2019Context = new AdventureWorks2019Context();
        }

        [HttpGet]
        public async Task<PersonDTO> Get()
        {
            return await _adventureWorks2019Context.Person.Include(p => p.BusinessEntity).Select(p =>
            new PersonDTO
            {
                BusinessEntityId = p.BusinessEntityId,
                NameStyle = p.NameStyle,
                PersonType = p.PersonType,
                Title = p.Title,
                Rowguid = p.Rowguid
            }).FirstAsync();
        }
    }
}