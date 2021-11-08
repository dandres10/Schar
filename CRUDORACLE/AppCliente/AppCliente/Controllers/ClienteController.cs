namespace AppCliente.Controllers
{
    using Business_Layer;
    using Entity_Layer;
    using System.Web.Mvc;

    public class ClienteController : Controller
    {
        // GET: Cliente
      

        public ActionResult Insert(ClienteBO dto)
        {

            NegCliente negCliente = new NegCliente();
            negCliente.Insertar(dto);
            return View();
            
        }

        public ActionResult Update(ClienteBO dto)
        {
            NegCliente negCliente = new NegCliente();
            negCliente.Actualizar(dto);
            return RedirectToAction("Listar");
       
        }

        public ActionResult Delete(string DNI)
        {

            NegCliente negCliente = new NegCliente();
            negCliente.Eliminar(DNI);
            return View();
        }

       
        public ActionResult Listar()
        {
            NegCliente negCliente = new NegCliente();
            
            return View(negCliente.Listar());
        }
    }
}