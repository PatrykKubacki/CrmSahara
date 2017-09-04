using System.Collections.Generic;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;

namespace CrmSahara.Domain.Repositories.Implementations
{
    public class PriorityRepository : IPriorityRepository
    {
        Entities _context = new Entities();
        public IEnumerable<Priority> Priorities => _context.Priority;

        public IEnumerable<Priority> GetAll() => Priorities;
    }
}
