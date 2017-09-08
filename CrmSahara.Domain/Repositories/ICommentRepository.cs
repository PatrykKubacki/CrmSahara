using System;
using System.Collections.Generic;
using System.Text;
using CrmSahara.Domain.Data;

namespace CrmSahara.Domain.Repositories.Abstract
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> Comments { get; }

        IEnumerable<Comment> GetAll();

        IEnumerable<Comment> Get(int taskItemId);

        void Save(Comment comment);
    }
}
