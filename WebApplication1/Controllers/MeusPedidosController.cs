using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    public class MeusPedidosController : Controller
    {
        public LoginModel Login
        {
            get { return (LoginModel)Session["Login"]; }
        }
        
        public ActionResult Index()
        {
            if (Login != null)
            {
                var model = new MeusPedidosModel();
                var apiServico = new ApiServico();

                model.Pedidos = apiServico.ObterPedidosCliente(Login.Id);

                return View(model);
            }

            return RedirectToAction("AcessoNegado", "Login");
        }
    }
}
