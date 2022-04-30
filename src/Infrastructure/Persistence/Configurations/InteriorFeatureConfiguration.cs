using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class InteriorFeatureConfiguration : IEntityTypeConfiguration<InteriorFeature>
	{
		public void Configure(EntityTypeBuilder<InteriorFeature> builder)
		{
			builder
				.ToTable(name: "InteriorFeature", schema: "dbo")
				.HasKey(s => s.InteriorFeaturesID);

			builder
				.HasOne(p => p.Classified)
				.WithOne(c => c.InteriorFeature)
				.HasForeignKey<Classified>(c => c.InteriorFeaturesID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(s => s.InteriorFeaturesID)
				.HasColumnName("InteriorFeaturesID")
				.HasColumnType("int");
			builder.Property(s => s.Elevator)
				.HasColumnName("Elevator")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.InternalStaircase)
				.HasColumnName("InternalStaircase")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.AirConditioning)
				.HasColumnName("AirConditioning")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Warehouse)
				.HasColumnName("Warehouse")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.PetsWelcome)
				.HasColumnName("PetsWelcome")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.SecurityDoor)
				.HasColumnName("SecurityDoor")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.DoubleGlazing)
				.HasColumnName("DoubleGlazing")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Furnished)
				.HasColumnName("Furnished")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Fireplace)
				.HasColumnName("Fireplace")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.UnderfloorHeating)
				.HasColumnName("UnderfloorHeating")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.SolarHeating)
				.HasColumnName("SolarHeating")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.NightCurrent)
				.HasColumnName("NightCurrent")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Garret)
				.HasColumnName("Garret")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Playroom)
				.HasColumnName("Playroom")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.SatelliteAntenna)
				.HasColumnName("SatelliteAntenna")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Alarm)
				.HasColumnName("Alarm")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.DoorScreens)
				.HasColumnName("DoorScreens")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Airy)
				.HasColumnName("Airy")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Painted)
				.HasColumnName("Painted")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.WithEquipment)
				.HasColumnName("WithEquipment")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.CableTV)
				.HasColumnName("CableTV")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.Wiring)
				.HasColumnName("Wiring")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.LoadingUnloadingElevator)
				.HasColumnName("LoadingUnloadingElevator")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.SuspendedCeiling)
				.HasColumnName("SuspendedCeiling")
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