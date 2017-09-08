using System;
using System.Diagnostics;
using System.Linq;
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
        private readonly ICommentRepository _commentRepository;

        public HomeController(ITaskRepository taskRepository, 
                              IUserRepository userRepository, 
                              IPriorityRepository priorityRepository,
                              ICommentRepository commentRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _priorityRepository = priorityRepository;
            _commentRepository = commentRepository;
        }

        public IActionResult Index(int? id, int? statusId)
        {
            if (statusId != null)
                return View(id == null
                    ? _taskRepository.GetAll().Where(t=>t.StatusId == statusId) 
                    : _taskRepository.GetForUser(id.Value).Where(t => t.StatusId == statusId));

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

        [HttpPost]
        public IActionResult CreateComment(int taskItemId,string description)
        {
            var comment = new Comment()
            {
                TaskItemId = taskItemId,
                Description = description,
                Date = DateTime.Now
            };
            _commentRepository.Save(comment);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}