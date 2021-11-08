namespace MiPrimerWebApiM3.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 15)]
       
        public ActionResult<string> Get() {
            return DateTime.Now.Second.ToString();
        }
    }
}