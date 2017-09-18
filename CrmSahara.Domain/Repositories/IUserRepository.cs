using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync(int id);
    }
}