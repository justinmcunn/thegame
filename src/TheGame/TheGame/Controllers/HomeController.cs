using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGame.Models;

namespace TheGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Lost(string name, string from)
        {
            var vm = new LostModel()
            {
                Name = name,
                From = from
            };

            return View(vm);
        }
    }
}