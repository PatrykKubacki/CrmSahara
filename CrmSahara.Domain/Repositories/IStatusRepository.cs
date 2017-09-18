using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories
{
    public interface IStatusRepository
    {
	    IEnumerable<Status> Statuses { get; }

	    Task<IEnumerable<Status>> GetAllAsync();
	    
	}
}