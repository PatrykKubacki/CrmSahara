using System;

namespace CrmSahara.Infrastructure.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? TaskItemId { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }

        public TaskItemDto TaskItem { get; set; }
        public UserDto User { get; set; }
    }
}
