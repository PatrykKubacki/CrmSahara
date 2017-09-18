using AutoMapper;
using CrmSahara.Domain.Data;
using CrmSahara.Infrastructure.Dto;

namespace CrmSahara.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
					cfg.CreateMap<TaskItem,TaskItemDto>().MaxDepth(3); ;
	                cfg.CreateMap<Priority, PriorityDto>().MaxDepth(3); ;
	                cfg.CreateMap<Status, StatusDto>().MaxDepth(3); ;
					cfg.CreateMap<User, UserDto>().MaxDepth(3); ;
                    cfg.CreateMap<Group, GroupDto>().MaxDepth(3); ;
                    cfg.CreateMap<Comment, CommentDto>().MaxDepth(3); ;
				})
                .CreateMapper();
    }
}
