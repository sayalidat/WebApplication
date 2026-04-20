using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Renders the default view for the application's home page.
        /// </summary>
        /// <returns>An ActionResult that renders the default view for the home page.</returns>
        public ActionResult Index()
        {
        int i= 10;
        if (i<5)
        {};
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Displays the Contact page.
        /// </summary>
        /// <returns>An ActionResult that renders the Contact view; ViewBag.Message contains the contact page message.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
//PR
//PR 2
