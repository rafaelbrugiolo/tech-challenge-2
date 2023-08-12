using PersonalBlog.Api.Dtos;

namespace PersonalBlog.Api.Services;

public interface INewsService
{
	IEnumerable<NewsResponseDto> GetAll();
	Task<NewsResponseDto> GetById(Guid id);
	Task<NewsResponseDto> Insert(NewsRequestInsertDto dto);
	Task<NewsResponseDto> Edit(Guid id, NewsRequestEditDto dto);
	Task DeleteByIdAsync(Guid id);
}
