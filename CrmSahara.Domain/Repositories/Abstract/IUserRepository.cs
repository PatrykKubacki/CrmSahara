using System.Collections.Generic;
using CrmSahara.Domain.Data;


namespace CrmSahara.Domain.Repositories.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        IEnumerable<User> GetAll();

        User Get(int id);
    }
}
