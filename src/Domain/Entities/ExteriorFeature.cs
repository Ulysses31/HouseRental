using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class ExteriorFeature : AuditableEntity
	{
		public virtual int ExteriorFeaturesID { get; set; }

		public virtual bool PropertyView { get; set; }

		public virtual bool Facade { get; set; }

		public virtual string Orientation { get; set; }

		public virtual string AccessFrom { get; set; }

		public virtual bool ResidentialZone { get; set; }

		public virtual bool ParkingSpot { get; set; }

		public virtual bool Awnings { get; set; }

		public virtual bool Garden { get; set; }

		public virtual bool DisabledAccess { get; set; }

		public virtual bool Pool { get; set; }

		public virtual bool Corner { get; set; }

		public virtual bool Veranda { get; set; }

		public virtual Int32? ShowcaseGlassLength { get; set; }

		public virtual bool? UnloadingRamp { get; set; }

		public virtual bool WithinCityPlan { get; set; }

		public virtual double StructureFactor { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string Description { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual Classified Classified { get; set; }
	}
}