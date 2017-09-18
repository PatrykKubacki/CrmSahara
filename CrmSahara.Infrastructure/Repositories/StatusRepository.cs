using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;

namespace CrmSahara.Infrastructure.Repositories
{
	public class StatusRepository : IStatusRepository
	{
		private readonly Entities _context = new Entities();
		public IEnumerable<Status> Statuses => _context.Status;

		public async Task<IEnumerable<Status>> GetAllAsync() 
			=> await Task.FromResult(Statuses);
	}
}