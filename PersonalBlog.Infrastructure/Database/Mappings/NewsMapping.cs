using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Domain.Entities;

namespace PersonalBlog.Infrastructure.Database.Mappings;
public class NewsMapping : IEntityTypeConfiguration<News>
{
	public void Configure(EntityTypeBuilder<News> builder)
	{
		builder.ToTable(nameof(News));

		builder.HasKey(x => x.Id);

		builder.Property(p => p.Headline)
			.IsRequired()
			.HasColumnName("Headline");

		builder.Property(p => p.Content)
			.IsRequired()
			.HasColumnName("Content");

		builder.Property(p => p.PublishDate)
			.IsRequired()
			.HasColumnName("PictureFileName");

		builder.Property(p => p.Author)
			.IsRequired()
			.HasColumnName("Author");
	}
}