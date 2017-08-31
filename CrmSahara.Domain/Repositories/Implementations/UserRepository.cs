using System.Collections.Generic;
using System.Linq;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;

namespace CrmSahara.Domain.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        Entities _context = new Entities();
        public IEnumerable<User> Users => _context.User;

        public IEnumerable<User> GetAll() => Users;

        public User Get(int id) => Users.SingleOrDefault(u => u.Id == id);

    }
}