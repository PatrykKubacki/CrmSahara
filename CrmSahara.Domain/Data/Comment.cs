using System;
using System.Collections.Generic;

namespace CrmSahara.Domain.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? TaskItemId { get; set; }
        public DateTime Date { get; set; }
        /*TODO UserID*/

        public TaskItem TaskItem { get; set; }
    }
}
