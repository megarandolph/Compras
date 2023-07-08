using Compras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Compras.Controllers
{
    public class HomeController : Controller
    {
        private DBComprasEntities db = new DBComprasEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            Session["Acceso"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            var validate = db.usuarios.Where(x=> x.User == User && x.Pass == Pass).ToList();

            if (validate.Any())
            {
                Session["Acceso"] = "Exito";
                Session["Nombre"] = validate[0].Nombre+" "+ validate[0].Apellido;
                
                return RedirectToAction("Index");
            }
            else {
                ViewBag.Message = string.Format("Usuario o contrasaña incorrecta. Por favor intentarlo nuevamente");
                Session["Acceso"] = null;
                return View();
            }
        }
    }
}