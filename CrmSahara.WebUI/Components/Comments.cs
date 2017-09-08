using System.Linq;
using CrmSahara.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmSahara.WebUI.Components
{
    public class Comments : ViewComponent
    {
        readonly ICommentRepository _repository;

        public Comments(ICommentRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(int taskItemId) 
            => View(_repository.Get(taskItemId));
    }
}