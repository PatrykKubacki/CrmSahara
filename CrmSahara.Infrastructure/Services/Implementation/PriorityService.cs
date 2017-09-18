using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using CrmSahara.Infrastructure.Dto;
using CrmSahara.Infrastructure.Services.Abstract;

namespace CrmSahara.Infrastructure.Services.Implementation
{
	public class PriorityService : IPriorityService
	{
		IPriorityRepository _repository;
		IMapper _mapper;

		public PriorityService(IPriorityRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PriorityDto>> GetAllAsync()
		{
			var priorities = await _repository.GetAllAsync();

			return _mapper.Map<IEnumerable<Priority>, IEnumerable<PriorityDto>>(priorities);
		}
	}
}