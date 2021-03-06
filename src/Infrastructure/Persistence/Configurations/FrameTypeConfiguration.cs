using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class FrameTypeConfiguration : IEntityTypeConfiguration<FrameType>
	{
		public void Configure(EntityTypeBuilder<FrameType> builder)
		{
			builder
				.ToTable(name: "FrameType", schema: "dbo")
				.HasKey(s => s.FrameTypeID);

			builder
				.HasMany(p => p.InteriorFeatures)
				.WithOne(c => c.FrameType)
				.HasForeignKey(c => c.FrameTypeID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(s => s.Title)
				.HasColumnName("Title")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(s => s.Description)
				.HasColumnName("Description")
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