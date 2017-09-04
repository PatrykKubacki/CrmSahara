using System;
using System.Diagnostics;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;
using CrmSahara.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrmSahara.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPriorityRepository _priorityRepository;

        public HomeController(ITaskRepository taskRepository, 
                              IUserRepository userRepository, 
                              IPriorityRepository priorityRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _priorityRepository = priorityRepository;
        }

        public IActionResult Index(int? id)
        {
            return View(id == null ? _taskRepository.GetAll() : _taskRepository.GetForUser(id.Value));
        }

        public IActionResult Details(int id)
        {
            var taskItem = _taskRepository.Get(id);
            return PartialView("_Details", taskItem);
        }

        public IActionResult Create()
        {
            ViewBag.Priorities = new SelectList(_priorityRepository.GetAll(), "Id", "Name");
            ViewBag.Users = new SelectList(_userRepository.GetAll(), "Id", "UserName");
            return PartialView(new TaskItem {StartAt = DateTime.Now, EndAt = DateTime.MaxValue});
        }
        
        [HttpPost]
        public IActionResult Create(TaskItem item)
        {
            _taskRepository.Save(item);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}