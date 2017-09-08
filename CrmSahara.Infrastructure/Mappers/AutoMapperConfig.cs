using AutoMapper;

namespace CrmSahara.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                })
                .CreateMapper();
    }
}
