using System.Collections.Generic;
using System.Linq;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CrmSahara.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        Entities _context = new Entities();
        public IEnumerable<User> Users => _context.User.Include(u=>u.TaskItem)
                                                       .Include(u=>u.Group);

        public IEnumerable<User> GetAll() => Users;

        public User Get(int id) => Users.SingleOrDefault(u => u.Id == id);

    }
}