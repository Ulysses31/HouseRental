using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class ClassifiedConstructionConfiguration : IEntityTypeConfiguration<ClassifiedConstruction>
	{
		public void Configure(EntityTypeBuilder<ClassifiedConstruction> builder)
		{
			builder
				.ToTable(name: "ClassifiedConstruction", schema: "dbo")
				.HasKey(s => s.ClassifiedConstructionID);

			builder
				.HasOne(p => p.Classified)
				.WithOne(c => c.ClassifiedConstruction)
				.HasForeignKey<Classified>(c => c.ClassifiedConstructionID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(s => s.ClassifiedConstructionID)
				.HasColumnName("ClassifiedConstructionID")
				.HasColumnType("int");
			builder.Property(s => s.PentHouse)
				.HasColumnName("PentHouse")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.NewlyBuilt)
				.HasColumnName("NewlyBuilt")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Renovated)
				.HasColumnName("Renovated")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.NeedsToBeRenovated)
				.HasColumnName("NeedsToBeRenovated")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.NeoClassical)
				.HasColumnName("NeoClassical")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Preserved)
				.HasColumnName("Preserved")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Incomplete)
				.HasColumnName("Incomplete")
				.HasColumnType("bit")
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