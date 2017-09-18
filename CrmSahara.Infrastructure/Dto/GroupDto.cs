using System.Collections.Generic;

namespace CrmSahara.Infrastructure.Dto
{
    public  class GroupDto
    {
	    public GroupDto()
		{
		    User = new HashSet<UserDto>();
	    }

		public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserDto> User { get; set; }
    }
}
