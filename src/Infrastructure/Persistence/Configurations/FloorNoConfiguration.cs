using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class FloorNoConfiguration : IEntityTypeConfiguration<FloorNo>
	{
		public void Configure(EntityTypeBuilder<FloorNo> builder)
		{
			builder
				.ToTable(name: "FloorNo", schema: "dbo")
				.HasKey(f => f.FloorNoID);

			builder
				.HasMany(p => p.Classifieds)
				.WithOne(c => c.FloorNo)
				.HasForeignKey(c => c.FloorNoID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(f => f.FloorNoID)
				.HasColumnName("FloorNoID")
				.HasColumnType("int");
			builder.Property(f => f.FloorNoValue)
				.HasColumnName("FloorNoValue")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(f => f.Description)
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