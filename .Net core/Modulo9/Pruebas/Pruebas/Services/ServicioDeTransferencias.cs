namespace Pruebas.Services
{
    using Pruebas.Entities;
    using System;

    public class ServicioDeTransferencias
    {
        private readonly IServicioValidacionesDeTransferencias _servicioValidaciones;

        public ServicioDeTransferencias()
        {

        }


        public ServicioDeTransferencias(IServicioValidacionesDeTransferencias servicioValidaciones)
        {
            _servicioValidaciones = servicioValidaciones;
        }

        public void TransferirEntreCuentas(Cuenta origen, Cuenta destino, decimal montoATransferir)
        {
            var mensajeError = _servicioValidaciones.RealizarValidaciones(origen, destino, montoATransferir);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                throw new ApplicationException(mensajeError);
            }

            origen.Fondos -= montoATransferir;
            destino.Fondos += montoATransferir;
        }
    }
}