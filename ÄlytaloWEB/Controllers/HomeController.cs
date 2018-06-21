using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ÄlytaloWEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Selain = Request.UserAgent;

            if (Session["EndDate"] == null)
            {
                Session["EndDate"] = DateTime.Now.AddMinutes(1).ToString("dd-MM-yyy h:mm:ss tt");
            }

            ViewBag.Message = "Muokkaa timer -tietoa";
            ViewBag.EndDate = Session["EndDate"];

            return View();
        }
        public ActionResult HomeControl()
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
    }
}