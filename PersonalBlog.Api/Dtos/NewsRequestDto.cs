namespace PersonalBlog.Api.Dtos;

public class NewsRequestDto
{
	public string Headline { get; set; }
	public string Content { get; set; }
	public DateTime PublishDate { get; set; }
	public string Author { get; set; }
}
