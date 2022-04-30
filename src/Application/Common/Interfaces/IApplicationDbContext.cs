using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		//DbSet<DbLog> DbLogs { get; set; }
		DbSet<Classified> Classifieds { get; set; }

		DbSet<AdvertiserInfo> AdvertiserInfos { get; set; }
		DbSet<ClassifiedPurpose> ClassifiedPurposes { get; set; }
		DbSet<ClassifiedType> ClassifiedTypes { get; set; }
		DbSet<ClassifiedConstruction> ClassifiedConstructions { get; set; }
		DbSet<ClassifiedCharacteristics> ClassifiedCharacteristics { get; set; }
		DbSet<EnergyClass> EnergyClasses { get; set; }
		DbSet<FloorNo> FloorNos { get; set; }
		DbSet<FloorType> FloorTypes { get; set; }
		DbSet<FrameType> FrameTypes { get; set; }
		DbSet<PowerType> PowerTypes { get; set; }
		DbSet<GoogleMapPlace> GoogleMapPlaces { get; set; }
		DbSet<HeatingSystem> HeatingSystems { get; set; }
		DbSet<HeatingType> HeatingTypes { get; set; }
		DbSet<SuitableFor> SuitableFors { get; set; }
		DbSet<ExteriorFeature> ExteriorFeatures { get; set; }
		DbSet<InteriorFeature> InteriorFeatures { get; set; }
		DbSet<Photos> Photos { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);

		EntityEntry Entry(object entity);
	}
}