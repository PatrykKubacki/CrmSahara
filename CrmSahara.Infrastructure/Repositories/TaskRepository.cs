using System.Collections.Generic;
using System.Linq;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CrmSahara.Infrastructure.Repositories
{
    public class TaskRepository :ITaskRepository
    {
        Entities _context = new Entities();
        public IEnumerable<TaskItem> Tasks => _context.TaskItem.Include(t => t.User)
                                                               .Include(t => t.Priority)
                                                               .Include(t=>t.Comment);
     
        public IEnumerable<TaskItem> GetAll() => Tasks;

        public IEnumerable<TaskItem> GetForUser(int userId) => Tasks.Where(ti => ti.UserId == userId);

        public TaskItem Get(int id) => Tasks.SingleOrDefault(ti=>ti.Id == id);

        public void Save(TaskItem item)
        {
            if (item.Id == 0)
                _context.TaskItem.Add(item);
            else
            {
                var dbEntry = _context.TaskItem.SingleOrDefault(i => i.Id == item.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = item.Id;
                    dbEntry.Name = item.Name;
                    dbEntry.UserId = item.UserId;
                    dbEntry.EndAt = item.EndAt;
                    dbEntry.StartAt = item.StartAt;
                    dbEntry.PriorityId = item.PriorityId;
                    dbEntry.Description = item.Description;
                }
            }
            _context.SaveChanges();
        }
    }
}