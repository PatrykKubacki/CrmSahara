using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using CrmSahara.Infrastructure.Dto;
using CrmSahara.Infrastructure.Services.Abstract;

namespace CrmSahara.Infrastructure.Services.Implementation
{
	public class TaskService : ITaskService
	{
		ITaskRepository _repository;
		IMapper _mapper;

		public TaskService(ITaskRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<TaskItemDto>> GetAllAsync()
		{
			var taskItems = await _repository.GetAllAsync();

			return _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);
		}

		public async Task<IEnumerable<TaskItemDto>> GetForUserAsync(int userId)
		{
			var taskItems = await _repository.GetForUserAsync(userId);

			return _mapper.Map<IEnumerable<TaskItem>, IEnumerable<TaskItemDto>>(taskItems);
		}

		public async Task<IEnumerable<TaskItemDto>> GetWhenStatusAsync(int statusId)
		{
			var taskItems = await _repository.GetWhenStatusAsync(statusId);

			return _mapper.Map<IEnumerable<TaskItem>, IEnumerable<TaskItemDto>>(taskItems);
		}

		public async Task<IEnumerable<TaskItemDto>> GetAsync(int userId, int statusId)
		{
			var taskItems = await _repository.GetAsync(userId,statusId);

			return _mapper.Map<IEnumerable<TaskItem>, IEnumerable<TaskItemDto>>(taskItems);
		}

		public async Task<TaskItemDto> GetAsync(int id)
		{
			var taskItem = await _repository.GetAsync(id);

			return _mapper.Map<TaskItem, TaskItemDto>(taskItem);
		}

		public async Task SaveAsync(TaskItemDto itemDto)
		{
			var taskItem = _mapper.Map<TaskItemDto, TaskItem>(itemDto);
			await _repository.SaveAsync(taskItem);
		}
	}
}