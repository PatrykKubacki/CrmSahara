using System.Collections.Generic;
using System.Threading.Tasks;
using CrmSahara.Infrastructure.Dto;

namespace CrmSahara.Infrastructure.Services.Abstract
{
    public interface IUserService : IService
	{
        Task<IEnumerable<UserDto>> GetAllAsync();

        Task<UserDto> GetAsync(int id);
    }
}