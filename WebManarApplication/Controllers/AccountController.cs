using Microsoft.AspNetCore.Mvc;

namespace WebManarApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
