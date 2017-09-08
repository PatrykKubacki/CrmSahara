using System.Collections.Generic;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories.Abstract
{
    public interface IPriorityRepository
    {
        IEnumerable<Priority> Priorities { get; }

        IEnumerable<Priority> GetAll();
    }
}
