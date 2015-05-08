using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using TheGame.Models;

namespace TheGame.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(LostModel model)
        {
            using (var client = new HttpClient())
            {
                var apiKey = "dc6zaTOxFJmzC";

                var target = $"http://api.giphy.com/v1/gifs/random?api_key={apiKey}";
 
                var request = await client.GetStringAsync(target);

                model.LaughingAtYourLossImage = JsonConvert.DeserializeObject<GiphyModel>(request).Data.ImageUrl;
            }

            model.From = "Justin";
            model.Name = "Rion";

            return View(model);
        }
    }
}
