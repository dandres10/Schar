using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.DTO
{
    public class PersonDTO
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }

        public Guid Rowguid { get; set; }
    }
}
