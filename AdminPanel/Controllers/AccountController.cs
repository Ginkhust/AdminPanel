using System;
using System.Web.Mvc;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AdminPanel.Controllers
{
    
    public class AccountController : Controller
    {
        [Route("")]
        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<ActionResult> Login(FormCollection fc)
        { 
            try
            { 
                await ParseUser.LogInAsync(fc["Name"], fc["Password"]);

                ViewBag.Username = fc["Name"];
                return RedirectToAction("Home");
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", e.Message);
            }


        }
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}