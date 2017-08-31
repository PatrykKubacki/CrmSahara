using System;
using System.Collections.Generic;

namespace CrmSahara.Domain.Data
{
    public partial class User
    {
        public User()
        {
            TaskItem = new HashSet<TaskItem>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? GroupId { get; set; }

        public Group Group { get; set; }
        public ICollection<TaskItem> TaskItem { get; set; }
    }
}
