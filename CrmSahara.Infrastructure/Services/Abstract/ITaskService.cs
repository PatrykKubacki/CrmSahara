using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Infrastructure.Dto;

namespace CrmSahara.Infrastructure.Services.Abstract
{
	public interface ITaskService : IService
	{
		Task<IEnumerable<TaskItemDto>> GetAllAsync();

		Task<IEnumerable<TaskItemDto>> GetForUserAsync(int userId);

		Task<IEnumerable<TaskItemDto>> GetWhenStatusAsync(int statusId);

		Task<IEnumerable<TaskItemDto>> GetAsync(int userId, int statusId);

		Task<TaskItemDto> GetAsync(int id);

		Task SaveAsync(TaskItemDto item);
	}
}