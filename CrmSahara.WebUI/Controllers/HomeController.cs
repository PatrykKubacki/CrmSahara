using System.Diagnostics;
using CrmSahara.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}