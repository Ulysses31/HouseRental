using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class ExteriorFeatureConfiguration : IEntityTypeConfiguration<ExteriorFeature>
	{
		public void Configure(EntityTypeBuilder<ExteriorFeature> builder)
		{
			builder
				.ToTable(name: "ExteriorFeature", schema: "dbo")
				.HasKey(s => s.ExteriorFeaturesID);

			builder
				.HasOne(p => p.Classified)
				.WithOne(c => c.ExteriorFeature)
				.HasForeignKey<Classified>(c => c.ExteriorFeaturesID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(s => s.ExteriorFeaturesID)
				.HasColumnName("ExteriorFeaturesID")
				.HasColumnType("int");
			builder.Property(s => s.PropertyView)
				.HasColumnName("PropertyView")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Facade)
				.HasColumnName("Facade")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.ResidentialZone)
				.HasColumnName("ResidentialZone")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.ParkingSpot)
				.HasColumnName("ParkingSpot")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Awnings)
				.HasColumnName("Awnings")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Garden)
				.HasColumnName("Garden")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.DisabledAccess)
				.HasColumnName("DisabledAccess")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Pool)
				.HasColumnName("Pool")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Corner)
				.HasColumnName("Corner")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Veranda)
				.HasColumnName("Veranda")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.UnloadingRamp)
				.HasColumnName("UnloadingRamp")
				.HasColumnType("bit");
			builder.Property(s => s.WithinCityPlan)
				.HasColumnName("WithinCityPlan")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.StructureFactor)
				.HasColumnName("StructureFactor")
				.HasColumnType("decimal(10,2)")
				.IsRequired();
			builder.Property(s => s.Orientation)
				.HasColumnName("Orientation")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(s => s.AccessFrom)
				.HasColumnName("AccessFrom")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.HasDefaultValue("Άσφαλτο")
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