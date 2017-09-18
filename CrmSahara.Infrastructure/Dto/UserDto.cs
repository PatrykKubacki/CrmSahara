using System.Collections.Generic;

namespace CrmSahara.Infrastructure.Dto
{
	public class UserDto
	{
		public UserDto()
		{
			Comment = new HashSet<CommentDto>();
			TaskItem = new HashSet<TaskItemDto>();
		}

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int? GroupId { get; set; }

		public GroupDto Group { get; set; }
		public ICollection<CommentDto> Comment { get; set; }
		public ICollection<TaskItemDto> TaskItem { get; set; }
	}
}