namespace MiPrimerWebApiM3.Entities
{
    using MiPrimerWebApiM3.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Autor //: IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public List<LibroDTO> Books { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(Nombre))
        //    {
        //        var primetaLetra = Nombre[0].ToString();
        //        if (primetaLetra != primetaLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula", new string[] { nameof(Nombre) });
        //        }
        //    }
        //}
    }
}