using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using CrmSahara.Infrastructure.Dto;
using CrmSahara.Infrastructure.Services.Abstract;

namespace CrmSahara.Infrastructure.Services.Implementation
{
	public class StatusService : IStatusService
	{
		IStatusRepository _repository;
		IMapper _mapper;

		public StatusService(IStatusRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<StatusDto>> GetAllAsync()
		{
			var statuses = await _repository.GetAllAsync();

			return _mapper.Map<IEnumerable<Status>, IEnumerable<StatusDto>>(statuses);
		}
	}
}