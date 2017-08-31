using System.Collections.Generic;
using System.Linq;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;

namespace CrmSahara.Domain.Repositories.Implementations
{
    public class TaskRepository :ITaskRepository
    {
        Entities _context = new Entities();
        public IEnumerable<TaskItem> Tasks => _context.TaskItem;

        public IEnumerable<TaskItem> GetAll() => Tasks;

        public IEnumerable<TaskItem> GetForUser(int userId) => Tasks.Where(ti => ti.UserId == userId);

        public TaskItem Get(int id) => Tasks.SingleOrDefault(ti=>ti.Id == id);
    }
}