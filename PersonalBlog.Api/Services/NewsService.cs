using AutoMapper;
using PersonalBlog.Api.Dtos;
using PersonalBlog.Api.Interfaces;
using PersonalBlog.Domain.Interfaces;

namespace PersonalBlog.Api.Services;

public class NewsService : INewsService
{
	private readonly INewsRepository _repository;
	private readonly IMapper _mapper;

	public NewsService(INewsRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public Task<NewsResponseDto> Insert(NewsRequestDto newsRequestDto)
	{
		throw new NotImplementedException();
	}

	public Task<NewsResponseDto> GetById(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<NewsResponseDto>> GetAll()
	{
		throw new NotImplementedException();
	}

	public Task<NewsResponseDto> Edit(Guid id, NewsRequestDto newsRequestDto)
	{
		throw new NotImplementedException();
	}

	public void DeleteById(Guid id)
	{
		throw new NotImplementedException();
	}
}