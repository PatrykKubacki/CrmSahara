﻿using System;

namespace CrmSahara.Domain.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? TaskItemId { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }

        public TaskItem TaskItem { get; set; }
        public User User { get; set; }
    }
}