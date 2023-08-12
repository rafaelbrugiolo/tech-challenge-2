using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Api.Commom;
using PersonalBlog.Api.Dtos;
using PersonalBlog.Api.Services;

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
	[ProducesResponseType(typeof(IEnumerable<NewsResponseDto>), StatusCodes.Status200OK)]
	public IActionResult Get()
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var result = _newsService.GetAll();
		return Ok(result);
	}

	[HttpGet("News/{id}")]
	[ProducesResponseType(typeof(NewsResponseDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Get(Guid id)
	{
		try
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			return Ok(await _newsService.GetById(id));
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
	}

	[HttpPost("News")]
	[ProducesResponseType(typeof(NewsResponseDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Insert(NewsRequestInsertDto dto)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var result = await _newsService.Insert(dto);
		return Ok(result);
	}

	[HttpPut("News/{id}")]
	[ProducesResponseType(typeof(NewsResponseDto), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Edit(Guid id, NewsRequestEditDto dto)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var result = await _newsService.Edit(id, dto);
		return Ok(result);
	}

	[HttpDelete("News/{id}")]
	[ProducesResponseType(typeof(NewsResponseDto), StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete(Guid id)
	{
		try
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _newsService.DeleteByIdAsync(id);
			return NoContent();
		}
		catch (ResourceNotFoundException ex)
		{
			return NotFound(ex.Message);
		}
	}
}