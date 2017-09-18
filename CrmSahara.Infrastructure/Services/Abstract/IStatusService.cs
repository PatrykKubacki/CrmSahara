using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Infrastructure.Dto;

namespace CrmSahara.Infrastructure.Services.Abstract
{
	public interface IStatusService : IService
	{
		Task<IEnumerable<StatusDto>> GetAllAsync();
	}
}