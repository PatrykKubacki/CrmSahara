using System;
using System.Collections.Generic;

namespace CrmSahara.Domain.Data
{
    public partial class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PriorityId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int? UserId { get; set; }

        public Priority Priority { get; set; }
        public User User { get; set; }
    }
}
