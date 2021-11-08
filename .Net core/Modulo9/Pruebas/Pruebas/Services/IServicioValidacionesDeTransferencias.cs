namespace Pruebas.Services
{
    using Pruebas.Entities;

    public interface IServicioValidacionesDeTransferencias
    {
        string RealizarValidaciones(Cuenta origen, Cuenta destino, decimal montoATransferir);
    }
}