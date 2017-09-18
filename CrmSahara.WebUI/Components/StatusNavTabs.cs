using CrmSahara.Infrastructure.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Components
{
    public class StatusNavTabs : ViewComponent
    {
        readonly IStatusService _service;

	    public StatusNavTabs(IStatusService service)
	    {
		    _service = service;
	    }

	    public IViewComponentResult Invoke()
        {
            ViewBag.SelectedUser = RouteData?.Values["id"];
            ViewBag.SelectedStatus = RouteData?.Values["statusId"];
            return View(_service.GetAllAsync().Result);
        }
    }
}
