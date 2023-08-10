using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Api.Dtos;
using PersonalBlog.Api.Interfaces;

namespace PersonalBlog.Controllers;

[ApiController]
public class NewsController : ControllerBase
{
	private readonly INewsService _newsService;

	public NewsController(INewsService newsService)
	{
		_newsService = newsService;
	}

	[HttpGet("News")]
	public async Task<IEnumerable<NewsResponseDto>> Get()
	{
		return await _newsService.GetAll();
	}

	[HttpGet("News/{id}")]
	public async Task<NewsResponseDto> Get(Guid id)
	{
		return await _newsService.GetById(id);
	}

	[HttpPost("News")]
	public async Task<NewsResponseDto> Insert(NewsRequestDto newsResquestDto)
	{
		return await _newsService.Insert(newsResquestDto);
	}

	[HttpPut("News/{id}")]
	public async Task<NewsResponseDto> Edit(Guid id, NewsRequestDto newsResquestDto)
	{
		return await _newsService.Edit(id, newsResquestDto);
	}

	[HttpDelete("News/{id}")]
	public void Delete(Guid id)
	{
		_newsService.DeleteById(id);
	}
}
