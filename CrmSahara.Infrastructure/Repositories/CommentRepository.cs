using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrmSahara.Infrastructure.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly Entities _context = new Entities();

		public IEnumerable<Comment> Comments => _context.Comment.Include(c => c.User)
																.Include(c => c.TaskItem);

		public async Task<IEnumerable<Comment>> GetAllAsync() 
			=> await Task.FromResult(Comments);

		public async Task<IEnumerable<Comment>> GetAsync(int taskItemId) 
			=> await Task.FromResult(Comments.Where(c => c.TaskItemId == taskItemId));

		public async Task SaveAsync(Comment comment)
		{
			_context.Comment.Add(comment);
			_context.SaveChanges();
			await Task.CompletedTask;
		}
	}
}