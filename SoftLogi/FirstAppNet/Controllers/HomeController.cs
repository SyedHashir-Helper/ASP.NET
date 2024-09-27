using Microsoft.AspNetCore.Mvc;

namespace FirstAppNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();//You can also specify the name of the view in View("index");
            //return "First Run";
        }
    }
}
