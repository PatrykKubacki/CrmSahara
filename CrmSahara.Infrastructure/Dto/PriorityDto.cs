using System.Collections.Generic;

namespace CrmSahara.Infrastructure.Dto
{
    public  class PriorityDto
    {
	    public PriorityDto() {
		    TaskItem = new HashSet<TaskItemDto>();
	    }
		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TaskItemDto> TaskItem { get; set; }
    }
}
