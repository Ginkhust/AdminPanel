using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShipperList()
        {
            return View();
        }

        public ActionResult ShipperDivision()
        {
            return View();
        }
    }
}