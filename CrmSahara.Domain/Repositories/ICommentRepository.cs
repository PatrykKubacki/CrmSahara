using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> Comments { get; }

        Task<IEnumerable<Comment>> GetAllAsync();

        Task<IEnumerable<Comment>> GetAsync(int taskItemId);

        Task SaveAsync(Comment comment);
    }
}