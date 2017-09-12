using System;
using System.Collections.Generic;
using System.Linq;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CrmSahara.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        Entities _context = new Entities();
        public IEnumerable<Comment> Comments => _context.Comment.Include(c=>c.User)
                                                                 .Include(c=>c.TaskItem);

        public IEnumerable<Comment> GetAll() => Comments;

        public IEnumerable<Comment> Get(int taskItemId) => Comments.Where(c=>c.TaskItemId == taskItemId);

        public void Save(Comment comment)
        {
            _context.Comment.Add(comment);
            _context.SaveChanges();
        }
    }
}