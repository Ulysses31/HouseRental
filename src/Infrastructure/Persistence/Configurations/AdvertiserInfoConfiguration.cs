using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class AdvertiserInfoConfiguration : IEntityTypeConfiguration<AdvertiserInfo>
	{
		public void Configure(EntityTypeBuilder<AdvertiserInfo> builder)
		{
			builder
					.ToTable(name: "AdvertiserInfo", schema: "dbo")
					.HasKey(a => a.AdvertiserInfoID);

			builder
				.HasMany(p => p.Classifieds)
				.WithOne(c => c.AdvertiserInfo)
				.HasForeignKey(c => c.AdvertiserInfoID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(a => a.AdvertiserInfoID)
				.HasColumnName("AdvertiserInfoID")
				.HasColumnType("int");
			builder.Property(a => a.Code)
				.HasColumnName("Code")
				.HasColumnType("nvarchar(20)")
				.HasMaxLength(20)
				.IsRequired();
			builder.Property(a => a.Name)
				.HasColumnName("Name")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(a => a.Address)
				.HasColumnName("Address")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(a => a.Responsible)
				.HasColumnName("Responsible")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150)
				.IsRequired();
			builder.Property(a => a.Telephone)
				.HasColumnName("Telephone")
				.HasColumnType("nvarchar(15)")
				.HasMaxLength(15)
				.IsRequired();
			builder.Property(a => a.Email)
				.HasColumnName("Email")
				.HasColumnType("nvarchar(100)")
				.HasMaxLength(100);
			builder.Property(a => a.Website)
				.HasColumnName("Website")
				.HasColumnType("nvarchar(150)")
				.HasMaxLength(150);
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