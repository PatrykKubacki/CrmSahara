using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrmSahara.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        Entities _context = new Entities();

	    public IEnumerable<User> Users => _context.User.Include(u => u.TaskItem)
													   .Include(u => u.Group);

        public async Task<IEnumerable<User>> GetAllAsync() 
			=> await Task.FromResult(Users);

        public async Task<User> GetAsync(int id) 
			=> await Task.FromResult(Users.SingleOrDefault(u => u.Id == id));

    }
}