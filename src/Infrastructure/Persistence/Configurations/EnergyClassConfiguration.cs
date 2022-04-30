using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class EnergyClassConfiguration : IEntityTypeConfiguration<EnergyClass>
	{
		public void Configure(EntityTypeBuilder<EnergyClass> builder)
		{
			builder
				.ToTable(name: "EnergyClass", schema: "dbo")
				.HasKey(e => e.EnergyClassID);

			builder
				.HasMany(p => p.ClassifiedCharacteristics)
				.WithOne(c => c.EnergyClass)
				.HasForeignKey(c => c.EnergyClassID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(e => e.EnergyClassID)
				.HasColumnName("EnergyClassID")
				.HasColumnType("int");
			builder.Property(e => e.EnergyClassValue)
				.HasColumnName("EnergyClassValue")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(e => e.Description)
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