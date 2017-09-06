using System;
using System.Collections.Generic;
using System.Text;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;

namespace CrmSahara.Domain.Repositories.Implementations
{
   public class StatusRepository :IStatusRepository
    {
        Entities _context = new Entities();
        public IEnumerable<Status> Statuses => _context.Status;

        public IEnumerable<Status> GetAll() => Statuses;
    }
}
