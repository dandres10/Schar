using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApiVer01.Controllers;
using WebApiVer01.Entitys;
using WebApiVer01.Prueba;

namespace WebApiPruebasUnitarias
{
    [TestClass]
    public class AutoresControllerTest
    {
        [TestMethod]
        public async void Get_SiElAutorNoExiste_SeRetornaUn404()
        {
            //preparacion
            var idAutor = 1;
            var mock = new Mock<IRepositorioAutores>();
            mock.Setup(x => x.ObtenerPorId(idAutor)).Returns(default(Autor));
            var autoresController = new AutoresController(mock.Object);
            //prueba
           
            //verificacion
            Assert.IsInstanceOfType(data.Result, typeof(NotFoundResult));
        }
    }
}
