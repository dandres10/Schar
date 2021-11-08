namespace WebApiModulo7.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using WebApiModulo7.Services;

    [ApiController]
    [Route("[controller]")]
    [EnableCors("PermitirApiRequest")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IDataProtector _protector;
        private readonly HashService hashService;

        public WeatherForecastController(IDataProtectionProvider protectionProvider, HashService hashService)
        {
            this._protector = protectionProvider.CreateProtector("valor_unico");
            this.hashService = hashService;
        }

        [HttpGet("hash")]
        public ActionResult GetHash()
        {
            string textoPlano = "andres leon";
            var hashResult1 = hashService.Hash(textoPlano).Hash;
            var hashResult2 = hashService.Hash(textoPlano).Hash;
            return Ok(new { textoPlano, hashResult1, hashResult2 });
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            var protectorLimitadoPorTiempo = _protector.ToTimeLimitedDataProtector();
            string textoPlano = "andres leon";
            //string textoCifrado = _protector.Protect(textoPlano);
            string textoCifrado = protectorLimitadoPorTiempo.Protect(textoPlano, TimeSpan.FromSeconds(5));
            //Thread.Sleep(6000);
            //string textoDesencriptado = _protector.Unprotect(textoCifrado);
            string textoDesencriptado = protectorLimitadoPorTiempo.Unprotect(textoCifrado);
            return Ok(new { textoPlano, textoCifrado, textoDesencriptado });
        }
    }
}