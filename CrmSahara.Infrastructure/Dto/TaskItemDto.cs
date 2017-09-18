using System;
using System.Collections.Generic;

namespace CrmSahara.Infrastructure.Dto
{
    public  class TaskItemDto
    {
	    public TaskItemDto()
{
		    Comment = new HashSet<CommentDto>();
	    }

		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PriorityId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }

        public PriorityDto Priority { get; set; }
        public StatusDto Status { get; set; }
        public UserDto User { get; set; }
        public ICollection<CommentDto> Comment { get; set; }
    }
}
