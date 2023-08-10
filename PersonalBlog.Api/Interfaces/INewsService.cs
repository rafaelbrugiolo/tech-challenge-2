using PersonalBlog.Api.Dtos;

namespace PersonalBlog.Api.Interfaces;

public interface INewsService
{
	Task<IEnumerable<NewsResponseDto>> GetAll();
	Task<NewsResponseDto> GetById(Guid id);
	Task<NewsResponseDto> Insert(NewsRequestDto newsRequestDto);
	Task<NewsResponseDto> Edit(Guid id, NewsRequestDto newsRequestDto);
	void DeleteById(Guid id);
}
