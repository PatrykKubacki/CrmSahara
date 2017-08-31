using System.Diagnostics;
using CrmSahara.Domain.Repositories.Abstract;
using CrmSahara.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repository;

        public HomeController(ITaskRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int? id)
        {
            return View(id == null ? _repository.GetAll() : _repository.GetForUser(id.Value));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}