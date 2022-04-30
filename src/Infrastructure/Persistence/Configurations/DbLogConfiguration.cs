//using CleanArchitecture.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace CleanArchitecture.Infrastructure.Persistence.Configurations
//{
//	public class DbLogConfiguration : IEntityTypeConfiguration<DbLog>
//	{
//		public void Configure(EntityTypeBuilder<DbLog> builder)
//		{
//			builder
//				.ToTable(name: "DbLog", schema: "dbo")
//				.HasKey(f => f.DbLogId);
//			builder.Property(f => f.DbLogId)
//				.HasColumnName("DbLogId")
//				.HasColumnType("int");
//			builder.Property(f => f.Message)
//				.HasColumnName("Message")
//				.HasColumnType("nvarchar(max)");
//			builder.Property(f => f.MessageTemplate)
//				.HasColumnName("MessageTemplate")
//				.HasColumnType("nvarchar(max)");
//			builder.Property(f => f.Level)
//				.HasColumnName("Level")
//				.HasColumnType("nvarchar(max)");
//			builder.Property(a => a.TimeStamp)
//				.HasColumnName("TimeStamp")
//				.HasColumnType("datetime");
//			builder.Property(f => f.Properties)
//				.HasColumnName("Properties")
//				.HasColumnType("nvarchar(max)");
//			builder.Property(f => f.EventType)
//				.HasColumnName("EventType")
//				.HasColumnType("int");
//			builder.Property(f => f.Release)
//				.HasColumnName("Release")
//				.HasColumnType("nvarchar(32)")
//				.HasMaxLength(32);
//			builder.Property(f => f.OsVersion)
//				.HasColumnName("OsVersion")
//				.HasColumnType("nvarchar(50)")
//				.HasMaxLength(50);
//			builder.Property(f => f.ServerName)
//				.HasColumnName("ServerName")
//				.HasColumnType("nvarchar(50)")
//				.HasMaxLength(50);
//			builder.Property(f => f.UserName)
//				.HasColumnName("UserName")
//				.HasColumnType("nvarchar(100)")
//				.HasMaxLength(100);
//			builder.Property(f => f.UserDomainName)
//				.HasColumnName("UserDomainName")
//				.HasColumnType("nvarchar(150)")
//				.HasMaxLength(150);
//			builder.Property(f => f.Address)
//				.HasColumnName("Address")
//				.HasColumnType("nvarchar(150)")
//				.HasMaxLength(150);
//			builder.Property(f => f.All_SqlColumn_Defaults)
//				.HasColumnName("All_SqlColumn_Defaults")
//				.HasColumnType("nvarchar(max)");
//		}
//	}
//}