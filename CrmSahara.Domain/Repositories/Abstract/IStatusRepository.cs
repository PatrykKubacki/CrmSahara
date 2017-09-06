using System.Collections.Generic;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories.Abstract
{
    public interface IStatusRepository
    {
        IEnumerable<Status> Statuses { get; }

        IEnumerable<Status> GetAll();
    }
}