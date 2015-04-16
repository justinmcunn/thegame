using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TheGame.Helpers;
using TheGame.Models;

namespace TheGame.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Lost(LostModel model)
        {
            // Spice things up a little bit
            ViewBag.LaughingAtYourLossImage = await GiphyHelper.GetRandomGif(model.Tag) ?? Url.Content("~/Content/fiddy.gif");
            return View(model);
        }
    }
}