using Microsoft.AspNetCore.Mvc;
using WildlifeProject.Services.Home;

namespace WildlifeProject.Controllers
{
    public class HomeController : Controller
    {
        IServiceHome _homeService;
        public HomeController(IServiceHome homeService)
        {
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.ListOfNoticedAnimals = _homeService.GetNoticedAnimals();
                return View();

            }
            catch
            {

                return NotFound();
            }
        }
    }
}
