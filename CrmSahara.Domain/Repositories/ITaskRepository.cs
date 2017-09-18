using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> Tasks { get; }

        Task<IEnumerable<TaskItem>> GetAllAsync();

	    Task<IEnumerable<TaskItem>> GetForUserAsync(int userId);

		Task<IEnumerable<TaskItem>> GetWhenStatusAsync(int statusId);

		Task<IEnumerable<TaskItem>> GetAsync(int userId, int statusId);

        Task<TaskItem> GetAsync(int id);

        Task SaveAsync(TaskItem item);
    }
}