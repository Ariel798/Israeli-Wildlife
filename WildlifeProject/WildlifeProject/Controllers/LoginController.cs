using Microsoft.AspNetCore.Mvc;
using WildlifeProject.Services.AdminUserServices;
using WildlifeProject.Services.Login;

namespace WildlifeProject.Controllers
{
    public class LoginController : Controller
    {
        ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index(string messege)
        {
            try
            {
                ViewBag.Messege = messege;
                return View();

            }
            catch
            {

                return NotFound();
            }
        }
    }
}
