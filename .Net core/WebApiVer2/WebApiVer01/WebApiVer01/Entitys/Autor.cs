namespace WebApiVer01.Entitys
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WebApiVer01.Helpers;

    public class Autor: IValidatableObject
    {
        public int Id { get; set; }

        [PrimeraLetraMayusculaAtribute]
        public string Nombre { get; set; }

        [Range(18, 120)]
        public int Edad { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }

        [Url]
        public string Url { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primetaLetra = Nombre[0].ToString();
                if (primetaLetra != primetaLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula", new string[] { nameof(Nombre) });
                }
            }
        }
    }
}