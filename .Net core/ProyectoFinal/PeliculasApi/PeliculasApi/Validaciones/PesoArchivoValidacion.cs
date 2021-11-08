namespace PeliculasApi.Validaciones
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class PesoArchivoValidacion : ValidationAttribute
    {
        private readonly int pesoMaximoEnMEgaBytes;

        public PesoArchivoValidacion(int PesoMaximoEnMEgaBytes)
        {
            pesoMaximoEnMEgaBytes = PesoMaximoEnMEgaBytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > pesoMaximoEnMEgaBytes * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor a {pesoMaximoEnMEgaBytes}mb");
            }

            return ValidationResult.Success;
        }
    }
}