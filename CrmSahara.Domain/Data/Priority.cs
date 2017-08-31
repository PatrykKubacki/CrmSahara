using System;
using System.Collections.Generic;

namespace CrmSahara.Domain.Data
{
    public partial class Priority
    {
        public Priority()
        {
            TaskItem = new HashSet<TaskItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TaskItem> TaskItem { get; set; }
    }
}
