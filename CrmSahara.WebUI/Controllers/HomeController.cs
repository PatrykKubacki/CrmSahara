using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CrmSahara.Infrastructure.Dto;
using CrmSahara.Infrastructure.Services.Abstract;
using CrmSahara.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrmSahara.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly ITaskService _taskService;
        readonly IUserService _userService;
        readonly IPriorityService _priorityService;
        readonly ICommentService _commentService;

	    public HomeController(ITaskService taskService, IUserService userService, 
							  IPriorityService priorityService, ICommentService commentService)
	    {
		    _taskService = taskService;
		    _userService = userService;
		    _priorityService = priorityService;
		    _commentService = commentService;
	    }


	    public IActionResult Index(int? id, int? statusId)
        {
            if (statusId != null)
                return View(id == null
                    ? _taskService.GetWhenStatusAsync(statusId.Value).Result 
                    : _taskService.GetAsync(id.Value , statusId.Value).Result);

            return View(id == null ? _taskService.GetAllAsync().Result: _taskService.GetForUserAsync(id.Value).Result);
	       
        }

        public IActionResult Details(int id)
        {
            var taskItem = _taskService.GetAsync(id).Result;
            return PartialView("_Details", taskItem);
        }

        public IActionResult Create()
        {
            ViewBag.Priorities = new SelectList(_priorityService.GetAllAsync().Result, "Id", "Name");
            ViewBag.Users = new SelectList(_userService.GetAllAsync().Result, "Id", "UserName");
            return PartialView(new TaskItemDto {StartAt = DateTime.Now, EndAt = DateTime.MaxValue});
        }
        
        [HttpPost]
        public IActionResult Create(TaskItemDto item)
        {
            _taskService.SaveAsync(item);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateComment(int taskItemId,string description)
        {
            var comment = new CommentDto
            {
                TaskItemId = taskItemId,
                Description = description,
                Date = DateTime.Now
            };
            _commentService.SaveAsync(comment);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}