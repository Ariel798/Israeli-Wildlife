using Microsoft.AspNetCore.Mvc;
using WildlifeProject.Model;
using WildlifeProject.Services.AnimalDescription;

namespace WildlifeProject.Controllers
{
    public class AnimalDescriptionController : Controller
    {
        static Animal? animal;
        IAnimalDescriptionService _animalDescriptionService;
        
        public AnimalDescriptionController(IAnimalDescriptionService animalDescriptionService)
        {
            _animalDescriptionService = animalDescriptionService;
        }
        public IActionResult Index(int animalId)
        {
            try
            {
                animal = _animalDescriptionService.GetAnimal(animalId)[0];
                Comment comment = new Comment { CommentText = "", AnimalId = animal.AnimalId };
                ViewBag.Comment = comment;
                return View(animal);
            }
            catch
            {

                return NotFound();
            }
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id)
        {
            try
            {
            return PartialView(id);

            }
            catch
            {
                return PartialView();
            }
        }
    }
}
