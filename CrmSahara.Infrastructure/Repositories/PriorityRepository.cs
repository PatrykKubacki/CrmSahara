using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;

namespace CrmSahara.Infrastructure.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        Entities _context = new Entities();
        public IEnumerable<Priority> Priorities => _context.Priority;

        public async Task<IEnumerable<Priority>> GetAllAsync() 
			=> await Task.FromResult(Priorities);
    }
}
