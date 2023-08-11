using AutoMapper;
using PersonalBlog.Api.Commom;
using PersonalBlog.Api.Dtos;
using PersonalBlog.Domain.Entities;
using PersonalBlog.Domain.Interfaces;

namespace PersonalBlog.Api.Services;

public class NewsService : INewsService
{
	private readonly IBaseRepository<News> _repository;
	private readonly IMapper _mapper;

	public NewsService(IBaseRepository<News> repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<NewsResponseDto> Insert(NewsRequestInsertDto dto)
	{
		var news = _mapper.Map<News>(dto);
		await _repository.AddAsync(news);
		await _repository.SaveChangesAsync();
		return _mapper.Map<NewsResponseDto>(news);
	}

	public async Task<NewsResponseDto> GetById(Guid id)
	{
		var news = await _repository.FindAsync(id);
		if (news is null)
			throw new ResourceNotFoundException($"No news was found with the id: {id}");

		return _mapper.Map<NewsResponseDto>(news);
	}

	public IEnumerable<NewsResponseDto> GetAll()
	{
		var news = _repository.List().ToArray();
		return _mapper.Map<IEnumerable<NewsResponseDto>>(news);
	}

	public async Task<NewsResponseDto> Edit(Guid id, NewsRequestEditDto dto)
	{
		var news = await _repository.FindAsync(id);
		if (news is null)
			throw new ResourceNotFoundException($"No news was found with the id: {id}");

		news.UpdateDetails(dto.Headline, dto.Content);
		var savedNews = _repository.Update(news);
		await _repository.SaveChangesAsync();

		return _mapper.Map<NewsResponseDto>(savedNews);
	}

	public async Task DeleteByIdAsync(Guid id)
	{
		var news = await _repository.FindAsync(id);
		if (news is null)
			throw new ResourceNotFoundException($"No news was found with the id: {id}");
		
		await _repository.DeleteAsync(id);
		await _repository.SaveChangesAsync();
	}
}