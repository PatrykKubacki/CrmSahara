using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Infrastructure.Dto;

namespace CrmSahara.Infrastructure.Services.Abstract
{
	public interface IPriorityService : IService
	{
		Task<IEnumerable<PriorityDto>> GetAllAsync();
	}
}