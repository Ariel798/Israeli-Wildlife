using Microsoft.AspNetCore.Mvc;
using WildlifeProject.Services.Catalouge;

namespace WildlifeProject.Controllers
{
    public class CatalogueController : Controller
    {
        ICatalougeService _catalougeService;
        public CatalogueController(ICatalougeService catalougeService)
        {
            _catalougeService = catalougeService;
        }

        public IActionResult Index(int catagorySelect = 0)
        {
            try
            {
                if (catagorySelect != 0)
                {
                    ViewBag.ListOfAnimals = _catalougeService.GetFilterAnimals(catagorySelect);
                }
                else
                {
                    ViewBag.ListOfAnimals = _catalougeService.GetAnimals();
                }
                return View();
            }
            catch
            {

                return NotFound();
            }
        }
    }
}
