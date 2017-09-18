using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CrmSahara.Domain.Data;
using CrmSahara.Domain.Repositories;
using CrmSahara.Infrastructure.Dto;
using CrmSahara.Infrastructure.Services.Abstract;

namespace CrmSahara.Infrastructure.Services.Implementation
{
	public class CommentService : ICommentService
	{
		ICommentRepository _repository;
		IMapper _mapper;

		public CommentService(ICommentRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<CommentDto>> GetAllAsync()
		{
			var comments = await _repository.GetAllAsync();

			return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(comments);
		}

		public async Task<IEnumerable<CommentDto>> GetAsync(int taskItemId)
		{
			var comments = await _repository.GetAsync(taskItemId);

			return _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(comments);
		}

		public async Task SaveAsync(CommentDto commentDto)
		{
			var comment = _mapper.Map<CommentDto, Comment>(commentDto);
			await _repository.SaveAsync(comment);
		}
	}
}