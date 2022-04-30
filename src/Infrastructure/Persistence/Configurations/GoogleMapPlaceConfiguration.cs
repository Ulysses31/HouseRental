using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class GoogleMapPlaceConfiguration : IEntityTypeConfiguration<GoogleMapPlace>
	{
		public void Configure(EntityTypeBuilder<GoogleMapPlace> builder)
		{
			builder
				.ToTable(name: "GoogleMapPlace", schema: "dbo")
				.HasKey(g => g.GoogleMapPlaceID);

			builder
				.HasOne(p => p.Classified)
				.WithOne(c => c.GoogleMapPlace)
				.HasForeignKey<Classified>(c => c.GoogleMapPlaceID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(g => g.GoogleMapPlaceID)
				.HasColumnName("GoogleMapPlaceID")
				.HasColumnType("int");
			builder.Property(g => g.Area)
				.HasColumnName("Area")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(g => g.Latitude)
				.HasColumnName("Latitude")
				.HasColumnType("nvarchar(50)")
				.HasMaxLength(50)
				.IsRequired();
			builder.Property(g => g.Longitude)
				.HasColumnName("Longitude")
				.HasColumnType("nvarchar(50)")
				.HasMaxLength(50)
				.IsRequired();
			builder.Property(g => g.Description)
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