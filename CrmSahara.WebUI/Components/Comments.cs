using System.Collections.Generic;
using System.Linq;
using CrmSahara.Infrastructure.Dto;
using CrmSahara.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Components
{
    public class Comments : ViewComponent
    {
        readonly ICommentService _service;

	    public Comments(ICommentService commentService)
	    {
		    _service = commentService;
	    }

	    public IViewComponentResult Invoke(int taskItemId) 
            => View(_service.GetAsync(taskItemId).Result);
    }
}