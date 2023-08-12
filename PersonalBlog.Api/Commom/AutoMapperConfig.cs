using AutoMapper;
using PersonalBlog.Api.Dtos;
using PersonalBlog.Domain.Entities;

namespace PersonalBlog.Api.Commom;

public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
	{
		CreateMap<News, NewsRequestInsertDto>();
		CreateMap<NewsRequestInsertDto, News>();

		CreateMap<News, NewsResponseDto>();
		CreateMap<NewsResponseDto, News>();
	}
}