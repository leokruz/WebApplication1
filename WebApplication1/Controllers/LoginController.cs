using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                var apiServico = new ApiServico();
                var login = apiServico.VerificarAcesso(model.Email, model.Senha);

                if (login != null)
                {
                    Session["Login"] = login;
                    if (Session["SessionCarrinho"] == null)
                        return RedirectToAction("Index", "Checkout");
                    }
                else
                {
                    ViewBag.MensagemErroLogin = "Usuário e/ou senha inválidos.";
                    return View(model);
                }
            }
            else
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AcessoNegado()
        {
            return View();
        }

        public ActionResult Sair()
        {
            Session["Login"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt");

            var model = new LoginModel
            {
                IdPerfil = 1,
                Cliente = new ClienteModel()
            };

           

            return View(model);
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
