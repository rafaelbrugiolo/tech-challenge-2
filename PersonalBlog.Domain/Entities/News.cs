namespace PersonalBlog.Domain.Entities;
public class News : BaseEntity
{
	public string Headline { get; set; }
	public string Content { get; set; }
	public DateTime PublishDate { get; set; }
	public string Author { get; set; }
}