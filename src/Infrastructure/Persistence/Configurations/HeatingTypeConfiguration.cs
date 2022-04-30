using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class HeatingTypeConfiguration : IEntityTypeConfiguration<HeatingType>
	{
		public void Configure(EntityTypeBuilder<HeatingType> builder)
		{
			builder
				.ToTable(name: "HeatingType", schema: "dbo")
				.HasKey(h => h.HeatingTypeID);

			builder
				.HasMany(p => p.ClassifiedCharacteristics)
				.WithOne(c => c.HeatingType)
				.HasForeignKey(c => c.HeatingTypeID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(h => h.HeatingTypeID)
				.HasColumnName("HeatingTypeID")
				.HasColumnType("int");
			builder.Property(h => h.HeatingTypeValue)
				.HasColumnName("HeatingTypeValue")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(h => h.Description)
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