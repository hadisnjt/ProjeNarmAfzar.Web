using Microsoft.AspNetCore.Mvc;

namespace ProjeNarmAfzar.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
