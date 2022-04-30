using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class ClassifiedCharacteristicsConfiguration : IEntityTypeConfiguration<ClassifiedCharacteristics>
	{
		public void Configure(EntityTypeBuilder<ClassifiedCharacteristics> builder)
		{
			builder
				.ToTable(name: "ClassifiedCharacteristics", schema: "dbo")
				.HasKey(a => a.CharacteristicsID);

			builder
				.HasOne(p => p.Classified)
				.WithOne(p => p.ClassifiedCharacteristics)
				.HasForeignKey<Classified>(p => p.CharacteristicsID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(s => s.Price)
				.HasColumnName("Price")
				.HasColumnType("decimal(10, 2)")
				.IsRequired();
			builder.Property(s => s.PricePerTm)
				.HasColumnName("PricePerTm")
				.HasColumnType("decimal(10, 2)")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.AreaTm)
				.HasColumnName("AreaTm")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.LandAreaTm)
				.HasColumnName("LandAreaTm")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.Levels)
				.HasColumnName("Levels")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.Square)
				.HasColumnName("Square")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.Region)
				.HasColumnName("Region")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(s => s.Cuisines)
				.HasColumnName("Cuisines")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.Bathrooms)
				.HasColumnName("Bathrooms")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.Bedrooms)
				.HasColumnName("Bedrooms")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.ContructionYear)
				.HasColumnName("ContructionYear")
				.HasColumnType("int")
				.IsRequired();
			builder.Property(s => s.LandArea)
				.HasColumnName("LandArea")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.Lounges)
				.HasColumnName("Lounges")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.MonthlyShared)
				.HasColumnName("MonthlyShared")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.DistanceFromSea)
				.HasColumnName("DistanceFromSea")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.YearOfRenovation)
				.HasColumnName("YearOfRenovation")
				.HasColumnType("int")
				.IsRequired();
			builder.Property(s => s.BuildingCoefficient)
				.HasColumnName("BuildingCoefficient")
				.HasColumnType("int")
				.HasDefaultValue(0)
				.IsRequired();
			builder.Property(s => s.SystemCode)
				.HasColumnName("SystemCode")
				.HasColumnType("nvarchar(255)")
				.HasMaxLength(255)
				.IsRequired();
			builder.Property(s => s.PropertyCode)
				.HasColumnName("PropertyCode")
				.HasColumnType("nvarchar(255)")
				.HasMaxLength(255)
				.IsRequired();
			builder.Property(s => s.AvailableFrom)
				.HasColumnName("AvailableFrom")
				.HasColumnType("datetime");
			builder.Property(c => c.PublicationOfAdvert)
				.HasColumnName("PublicationOfAdvert")
				.HasColumnType("datetime")
				.IsRequired()
				.ValueGeneratedOnAdd();
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