using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using CrmSahara.Infrastructure.Dto;
using CrmSahara.Infrastructure.Mappers;
using CrmSahara.Infrastructure.Repositories;
using CrmSahara.Infrastructure.Services.Implementation;
using Moq;
using Xunit;

namespace CrmSahara.Tests
{
	public class MappingTests
    {
		[Fact]
	    public void CanMapTaskItemToDto()
		{
			var mockRepository = new Mock<ITaskRepository>();
			mockRepository.Setup(m => m.Tasks).Returns( new[]
			{
				new TaskItem{Id = 1, Name = "N1", Description = "D1"}, 
				new TaskItem{Id = 2, Name = "N2", Description = "D2" }, 
				new TaskItem{Id = 3, Name = "N3", Description = "D3"}, 
			});
			mockRepository.Setup(m => m.GetAsync(It.IsAny<int>()))
				.Returns( (int id) => Task.FromResult(mockRepository.Object.Tasks.SingleOrDefault(x=> x.Id == id)));

			var tasks = mockRepository.Object.Tasks;

			var target = new TaskService(mockRepository.Object,AutoMapperConfig.Initialize());

			var taskItemDto1 = target.GetAsync(1).Result;
			var taskItemDto2 = target.GetAsync(2).Result;
			var taskItemDto3 = target.GetAsync(3).Result;

			Assert.Equal(taskItemDto1.Id, tasks.SingleOrDefault(t=>t.Id == 1).Id);
			Assert.Equal(taskItemDto1.Name, tasks.SingleOrDefault(t => t.Id == 1).Name);
			Assert.Equal(taskItemDto1.Description, tasks.SingleOrDefault(t => t.Id == 1).Description);

			Assert.Equal(taskItemDto2.Id, tasks.SingleOrDefault(t=>t.Id == 2).Id);
			Assert.Equal(taskItemDto2.Name, tasks.SingleOrDefault(t => t.Id == 2).Name);
			Assert.Equal(taskItemDto2.Description, tasks.SingleOrDefault(t => t.Id == 2).Description);

			Assert.Equal(taskItemDto3.Id, tasks.SingleOrDefault(t=>t.Id == 3).Id);
			Assert.Equal(taskItemDto3.Name, tasks.SingleOrDefault(t => t.Id == 3).Name);
			Assert.Equal(taskItemDto3.Description, tasks.SingleOrDefault(t => t.Id == 3).Description);
		}

		[Fact]
		public void CanMapTaskItemsToDto() {
			var mockRepository = new Mock<ITaskRepository>();
			mockRepository.Setup(m => m.Tasks).Returns(new[]
			{
				new TaskItem{Id = 1, Name = "N1", Description = "D1"},
				new TaskItem{Id = 2, Name = "N2", Description = "D2" },
				new TaskItem{Id = 3, Name = "N3", Description = "D3"},
			});
			mockRepository.Setup(m => m.GetAllAsync())
				.Returns(Task.FromResult(mockRepository.Object.Tasks));

			var target = new TaskService(new TaskRepository(), AutoMapperConfig.Initialize());

			var taskItemsDto = target.GetAllAsync();

			Assert.NotNull(taskItemsDto);
		}
	}
}
