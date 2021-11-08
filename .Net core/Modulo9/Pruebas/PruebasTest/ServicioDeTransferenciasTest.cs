using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas.Entities;
using Pruebas.Services;
using System;

namespace PruebasTest
{
    [TestClass]
    public class ServicioDeTransferenciasTest
    {
        [TestMethod]
        public void TransferenciasEntreCuentasConFondosInsuficientesArrojaUnError()
        {
            //preparacion
            Exception expectedExcetion = null;
            Cuenta origen = new Cuenta() { Fondos = 0 };
            Cuenta destino = new Cuenta() { Fondos = 0 };
            decimal montoATransferir = 5m;
            var servicio = new ServicioDeTransferenciasSinMocks();


            //prueba
            try
            {
                servicio.TransferirEntreCuentas(origen, destino, montoATransferir);
                Assert.Fail("Un erro debio ser arrojado");
               
            }
            catch (Exception ex)
            {

                expectedExcetion = ex;
            }

            //verificacion
            Assert.IsTrue(expectedExcetion is ApplicationException);
            Assert.AreEqual("La cuenta origen no tiene fondos suficientes para realizar la operación", expectedExcetion.Message);
        }
    }
}
