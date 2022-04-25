using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult VerifyAccount()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
