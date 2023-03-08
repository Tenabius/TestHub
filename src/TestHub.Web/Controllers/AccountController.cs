using Microsoft.AspNetCore.Mvc;

namespace TestHub.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
