using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrmSahara.Infrastructure.Repositories
{
    public class TaskRepository :ITaskRepository
    {
        Entities _context = new Entities();
        public IEnumerable<TaskItem> Tasks => _context.TaskItem.Include(t => t.User)
                                                               .Include(t => t.Priority)
                                                               .Include(t=>t.Comment);
     
        public async Task<IEnumerable<TaskItem>> GetAllAsync() 
			=> await Task.FromResult(Tasks);

        public async  Task<IEnumerable<TaskItem>> GetForUserAsync(int userId) 
			=> await Task.FromResult(Tasks.Where(ti => ti.UserId == userId));

	    public async Task<IEnumerable<TaskItem>> GetWhenStatusAsync(int statusId)
		    => await Task.FromResult(Tasks.Where(t => t.StatusId == statusId));

	    public async Task<IEnumerable<TaskItem>> GetAsync(int userId, int statusId) 
			=> await Task.FromResult(GetForUserAsync(userId).Result
															.Intersect(GetWhenStatusAsync(statusId).Result));

		public async Task<TaskItem> GetAsync(int id)
			=> await Task.FromResult(Tasks.SingleOrDefault(ti=>ti.Id == id));

        public async Task SaveAsync(TaskItem item)
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
	        await Task.CompletedTask;
        }
    }
}