using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC2._0.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Repuestos()
        {
            return View();
        }
        public ActionResult Mantenimiento()
        {
            return View();
        }
    }
}