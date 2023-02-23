using Microsoft.AspNetCore.Mvc;
using System.Net;
using WildlifeProject.Model;
using WildlifeProject.Services.AdminUserServices;

namespace WildlifeProject.Controllers
{
    public class AdminController : Controller
    {
        private static bool _isAdmin;
        IAdminUserService _adminUser;
        public AdminController(IAdminUserService adminUser)
        {
            _adminUser = adminUser;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(AdminUser user)
        {
            try
            {
                if (_adminUser.ConfirmAdministrator(user))
                {
                    _isAdmin = true;
                    return View();
                }
                return RedirectToAction("Index", "Login", new { messege = "Unable to sign in" });
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult CreateAnimal()
        {
            try
            {
                return View();
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAnimal(Animal animal, [FromForm(Name = "Image")] IFormFile Image)
        {

            try
            {
                DisplayImage(animal, Image);
                if (ModelState.IsValid)
                {
                    if (!_adminUser.CreateAnimal(animal))
                    {
                        ViewBag.Alert = "Cannot add animal with an existing animal id!";
                        return View();
                    }
                    return View("SignIn");
                }
                return View();
            }
            catch
            {
                return NotFound();
            }
        }
        private static void DisplayImage(Animal animal, IFormFile Image)
        {
            if (Image != null)
            {
                if (Image.Length > 0)
                {

                    byte[]? p1 = null;
                    using (var fs1 = Image.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    animal.Image = p1;

                }
            }
        }
        public IActionResult Account()
        {
            try
            {
                if (_isAdmin)
                    return View("SignIn");
                else return Redirect("/Login/Index");
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult DeleteAnimal()
        {
            try
            {
                ViewBag.ListOfAnimals = _adminUser.GetAnimals();
                return View();

            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult Delete(int animalId, [FromForm(Name = "Image")] IFormFile Image)
        {
            try
            {
                Animal animal = _adminUser.GetAnimal(animalId)[0];
                DisplayImage(animal, Image);
                return View(animal);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteAnimal([FromForm] int animalId)
        {
            try
            {
                _adminUser.DeleteAnimal(animalId);
                return View("SignIn");
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult EditAnimal()
        {
            try
            {
                ViewBag.ListOfAnimals = _adminUser.GetAnimals();
                return View();
            }
            catch
            {
                return NotFound();
            }
        }
        public IActionResult Edit(int animalId, [FromForm(Name = "Image")] IFormFile Image)
        {
            try
            {
                Animal animal = _adminUser.GetAnimal(animalId)[0];
                DisplayImage(animal, Image);
                return View(animal);
            }
            catch
            {

                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult EditAnimal([FromForm] Animal animal, [FromForm(Name = "Image")] IFormFile Image)
        {
            try
            {
                DisplayImage(animal, Image);
                _adminUser.EditAnimal(animal);
                ViewData["StatusCode"] = (int)HttpStatusCode.Accepted;
                return RedirectToAction("EditAnimal");
            }
            catch(Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return NotFound();
            }
        }
    }
}
