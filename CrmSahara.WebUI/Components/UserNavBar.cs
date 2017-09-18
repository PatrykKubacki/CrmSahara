using CrmSahara.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Components
{
    public class UserNavBar : ViewComponent
    {
        readonly IUserService _service;

	    public UserNavBar(IUserService service)
	    {
		    _service = service;
	    }

	    public IViewComponentResult Invoke()
        {
            ViewBag.SelectedUser = RouteData?.Values["id"];
            return View(_service.GetAllAsync().Result);
        }
    }
}