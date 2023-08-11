namespace PersonalBlog.Domain.Entities;
public class News
{
	public Guid Id { get; set; }
	public string Headline { get; set; }
	public string Content { get; set; }
	public DateTime PublishDate { get; set; } = DateTime.Now;
	public string Author { get; set; }

	public void UpdateDetails(string headline, string content)
	{
		Headline = headline;
		Content = content;
	}
}