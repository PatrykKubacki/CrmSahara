using CrmSahara.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Components
{
    public class StatusNavTabs : ViewComponent
    {
        private readonly IStatusRepository _repository;

        public StatusNavTabs(IStatusRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedUser = RouteData?.Values["id"];
            ViewBag.SelectedStatus = RouteData?.Values["statusId"];
            return View(_repository.Statuses);
        }
    }
}
