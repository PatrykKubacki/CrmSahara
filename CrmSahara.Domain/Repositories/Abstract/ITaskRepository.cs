using System.Collections.Generic;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories.Abstract
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> Tasks { get; }

        IEnumerable<TaskItem> GetAll();

        IEnumerable<TaskItem> GetForUser(int userId);

        TaskItem Get(int id);

    }
}