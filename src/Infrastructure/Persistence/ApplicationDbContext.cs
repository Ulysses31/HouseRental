using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Services;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
	{
		private readonly ICurrentUserService _currentUserService;
		private readonly IDateTime _dateTime;
		private readonly IDomainEventService _domainEventService;

		public ApplicationDbContext(
				DbContextOptions<ApplicationDbContext> options,
				IOptions<OperationalStoreOptions> operationalStoreOptions,
				ICurrentUserService currentUserService,
				IDomainEventService domainEventService,
				IDateTime dateTime) : base(options, operationalStoreOptions)
		{
			_currentUserService = currentUserService;
			_domainEventService = domainEventService;
			_dateTime = dateTime;
		}

		//public DbSet<DbLog> DbLogs { get; set; }
		public DbSet<Classified> Classifieds { get; set; }
		public DbSet<AdvertiserInfo> AdvertiserInfos { get; set; }
		public DbSet<ClassifiedPurpose> ClassifiedPurposes { get; set; }
		public DbSet<ClassifiedType> ClassifiedTypes { get; set; }
		public DbSet<ClassifiedConstruction> ClassifiedConstructions { get; set; }
		public DbSet<ClassifiedCharacteristics> ClassifiedCharacteristics { get; set; }
		public DbSet<EnergyClass> EnergyClasses { get; set; }
		public DbSet<FloorNo> FloorNos { get; set; }
		public DbSet<FloorType> FloorTypes { get; set; }
		public DbSet<FrameType> FrameTypes { get; set; }
		public DbSet<PowerType> PowerTypes { get; set; }
		public DbSet<GoogleMapPlace> GoogleMapPlaces { get; set; }
		public DbSet<HeatingType> HeatingTypes { get; set; }
		public DbSet<HeatingSystem> HeatingSystems { get; set; }
		public DbSet<SuitableFor> SuitableFors { get; set; }
		public DbSet<ExteriorFeature> ExteriorFeatures { get; set; }
		public DbSet<InteriorFeature> InteriorFeatures { get; set; }
		public DbSet<Photos> Photos { get; set; }

		// public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
		// {
		// 	return base.Entry(entity);
		// }

		public override EntityEntry Entry(object entity)
		{
			return base.Entry(entity);
		}

		public override async Task<int> SaveChangesAsync(
			CancellationToken cancellationToken = new CancellationToken()
		)
		{
			foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
			{
				var ip = new IpAddressService();

				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.Guid = Guid.NewGuid();
						entry.Entity.CreatedBy = string.Format("{0} | {1} | {2}",
							ip.GetHostIpAddress(),
							Environment.UserDomainName,
							Environment.UserName
						);
						entry.Entity.Created = new DateTime(_dateTime.Now.Ticks);
						break;

					case EntityState.Modified:
						entry.Entity.LastModifiedBy = string.Format("{0} | {1} | {2}",
							ip.GetHostIpAddress(),
							Environment.UserDomainName,
							Environment.UserName
						);
						entry.Entity.LastModified = new DateTime(_dateTime.Now.Ticks);
						break;
				}
			}

			var events = ChangeTracker.Entries<IHasDomainEvent>()
							.Select(x => x.Entity.DomainEvents)
							.SelectMany(x => x)
							.Where(domainEvent => !domainEvent.IsPublished)
							.ToArray();

			var result = await base.SaveChangesAsync(cancellationToken);

			await DispatchEvents(events);

			return result;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			//builder.Entity<DbLog>();
			builder.Entity<Classified>();
			builder.Entity<AdvertiserInfo>();
			builder.Entity<ClassifiedPurpose>();
			builder.Entity<ClassifiedType>();
			builder.Entity<ClassifiedConstruction>();
			builder.Entity<ClassifiedCharacteristics>();
			builder.Entity<EnergyClass>();
			builder.Entity<FloorNo>();
			builder.Entity<FloorType>();
			builder.Entity<FrameType>();
			builder.Entity<PowerType>();
			builder.Entity<GoogleMapPlace>();
			builder.Entity<HeatingType>();
			builder.Entity<HeatingSystem>();
			builder.Entity<SuitableFor>();
			builder.Entity<ExteriorFeature>();
			builder.Entity<InteriorFeature>();
			builder.Entity<Photos>();
			base.OnModelCreating(builder);
		}

		private async Task DispatchEvents(DomainEvent[] events)
		{
			foreach (var @event in events)
			{
				@event.IsPublished = true;
				await _domainEventService.Publish(@event);
			}
		}
	}
}