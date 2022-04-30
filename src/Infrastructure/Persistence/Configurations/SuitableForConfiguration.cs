using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
	public class SuitableForConfiguration : IEntityTypeConfiguration<SuitableFor>
	{
		public void Configure(EntityTypeBuilder<SuitableFor> builder)
		{
			builder
				.ToTable(name: "SuitableFor", schema: "dbo")
				.HasKey(s => s.SuitableForID);

			builder
				.HasOne(p => p.Classified)
				.WithOne(c => c.SuitableFor)
				.HasForeignKey<Classified>(c => c.SuitableForID)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(s => s.SuitableForID)
				.HasColumnName("SuitableForID")
				.HasColumnType("int");
			builder.Property(s => s.StudentUse)
				.HasColumnName("StudentUse")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.HolidayHomeUse)
				.HasColumnName("HolidayHomeUse")
				.HasColumnType("bit")
				.IsRequired();
			builder.Property(s => s.InvestmentUse)
				.HasColumnName("InvestmentUse")
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