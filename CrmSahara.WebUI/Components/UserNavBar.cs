using CrmSahara.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Components
{
    public class UserNavBar : ViewComponent
    {
        private readonly IUserRepository _repository;

        public UserNavBar(IUserRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedUser = RouteData?.Values["id"];
            return View(_repository.Users);
        }
    }
}