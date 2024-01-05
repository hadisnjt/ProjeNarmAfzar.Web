using Microsoft.AspNetCore.Mvc;

namespace MyShop.Web.ViewComponents
{
    public class MainMenuViewComponent:ViewComponent 
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("MainMenu");
        }
    }
}
