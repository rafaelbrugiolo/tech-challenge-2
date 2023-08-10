namespace PersonalBlog.Api.Dtos;

public class NewsResponseDto
{
	public Guid Id { get; set; }
	public string Headline { get; set; }
	public string Content { get; set; }
	public DateTime PublishDate { get; set; }
	public string Author { get; set; }
}
