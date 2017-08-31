using System;
using System.Collections.Generic;

namespace CrmSahara.Domain.Data
{
    public partial class Group
    {
        public Group()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> User { get; set; }
    }
}
