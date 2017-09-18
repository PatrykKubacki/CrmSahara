using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Infrastructure.Dto;

namespace CrmSahara.Infrastructure.Services.Abstract
{
	public interface ICommentService : IService
	{
		Task<IEnumerable<CommentDto>> GetAllAsync();

		Task<IEnumerable<CommentDto>> GetAsync(int taskItemId);

		Task SaveAsync(CommentDto comment);
	}
}