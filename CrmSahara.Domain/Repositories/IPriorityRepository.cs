using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories
{
    public interface IPriorityRepository
    {
        IEnumerable<Priority> Priorities { get; }

        Task<IEnumerable<Priority>> GetAllAsync();
    }
}