using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {

        public LoginModel Login
        {
            get { return (LoginModel)Session["Login"]; }
        }

        // GET: Cliente
        public ActionResult Index()
        {
            if (Login != null)
            {
                
                var model = new ClienteModel();
                //var modelWs = new Fornecedor.Cliente();
                //var lista = new List<PedidoModel>();
                //var p = new PedidoModel();

                //Fornecedor.WebService1 ws = new Fornecedor.WebService1();

                //modelWs = ws.ObterCadastroCliente(Login.Id);
                                
                return View(model);
            }

            return RedirectToAction("AcessoNegado", "Login");
        }

        
    }
}
