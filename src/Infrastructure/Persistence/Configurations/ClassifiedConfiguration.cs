using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class ClassifiedConfiguration : IEntityTypeConfiguration<Classified>
	{
		public void Configure(EntityTypeBuilder<Classified> builder)
		{
			builder
				.ToTable(name: "Classified", schema: "dbo")
				.HasKey(a => a.ClassifiedID);
			builder.Property(s => s.ClassifiedTitle)
				.HasColumnName("ClassifiedTitle")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(s => s.ClassifiedDesription)
				.HasColumnName("ClassifiedDesription")
				.HasColumnType("nvarchar(255)")
				.HasMaxLength(255)
				.IsRequired();
			builder.Property(s => s.IsEnabled)
				.HasColumnName("IsEnabled")
				.HasColumnType("bit")
				.HasDefaultValue(true)
				.IsRequired();
			builder.Property(s => s.IsDeleted)
				.HasColumnName("IsDeleted")
				.HasColumnType("bit")
				.HasDefaultValue(false)
				.IsRequired();
			builder.Property(c => c.Guid)
				.HasColumnName("Guid")
				.HasColumnType("uniqueidentifier")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder
				.HasMany(p => p.Photos)
				.WithOne(c => c.Classified)
				.OnDelete(DeleteBehavior.Cascade)
				.IsRequired();
			builder.Property(c => c.Created)
				.HasColumnName("Created")
				.HasColumnType("datetime")
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(c => c.CreatedBy)
				.HasColumnName("CreatedBy")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150)
				.IsRequired()
				.ValueGeneratedOnAdd();
			builder.Property(c => c.LastModified)
				.HasColumnName("LastModified")
				.HasColumnType("datetime");
			builder.Property(c => c.LastModifiedBy)
				.HasColumnName("LastModifiedBy")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150);
		}
	}
}