using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CarrinhoController : Controller
    {
        public ActionResult Index()
        {
            if (Session["SessionCarrinho"] == null)
                Session["SessionCarrinho"] = new Models.CarrinhoModel();

            // Pega o carrinho atual da Sessão
            var sc = (Models.CarrinhoModel)Session["SessionCarrinho"];

            return View(sc);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["SessionCarrinho"] != null)
                {
                    var sc = (Models.CarrinhoModel)Session["SessionCarrinho"];
                    sc.RemoveItem(id);
                }
            }
            catch
            {

            }

            return RedirectToAction("Index");
        }
    }
}