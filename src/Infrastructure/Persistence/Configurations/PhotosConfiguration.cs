using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class PhotosConfiguration : IEntityTypeConfiguration<Photos>
	{
		public void Configure(EntityTypeBuilder<Photos> builder)
		{
			builder
				.ToTable(name: "Photos", schema: "dbo")
				.HasKey(p => p.PhotoID);

			builder
				.HasOne(p => p.Classified)
				.WithMany(c => c.Photos)
				.HasForeignKey(f => f.ClassifiedID)
				.OnDelete(DeleteBehavior.Cascade)
				.IsRequired();

			builder.Property(p => p.PhotoID)
				.HasColumnName("PhotoID")
				.HasColumnType("int");
			builder.Property(p => p.FileName)
				.HasColumnName("FileName")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(p => p.FileSize)
				.HasColumnName("FileSize")
				.HasColumnType("decimal(10,2)")
				.IsRequired();
			builder.Property(p => p.FileContent)
				.HasColumnName("FileContent")
				.HasColumnType("varbinary")
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