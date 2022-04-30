using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class ClassifiedCharacteristics : AuditableEntity
	{
		public virtual int CharacteristicsID { get; set; }

		public virtual double Price { get; set; }

		public virtual double PricePerTm { get; set; }

		public virtual Int32 AreaTm { get; set; }

		public virtual Int32 LandAreaTm { get; set; }

		public virtual Int32 Levels { get; set; }

		public virtual Int32 Square { get; set; }

		[StringLength(100, MinimumLength = 0)]
		public virtual string Region { get; set; }

		public virtual Int32 Cuisines { get; set; }

		public virtual Int32 Bathrooms { get; set; }

		public virtual Int32 Bedrooms { get; set; }

		public virtual int HeatingTypeID { get; set; }

		public virtual HeatingType HeatingType { get; set; }

		public virtual int HeatingSystemID { get; set; }

		public virtual HeatingSystem HeatingSystem { get; set; }

		public virtual int EnergyClassID { get; set; }

		public virtual EnergyClass EnergyClass { get; set; }

		public virtual Int32 ContructionYear { get; set; }

		public virtual Int32 LandArea { get; set; }

		public virtual Int32 Lounges { get; set; }

		public virtual double MonthlyShared { get; set; }

		public virtual double DistanceFromSea { get; set; }

		public virtual Int32 YearOfRenovation { get; set; }

		public virtual double BuildingCoefficient { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string SystemCode { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string PropertyCode { get; set; }

		public virtual DateTime? AvailableFrom { get; set; }

		public virtual DateTime? PublicationOfAdvert { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string Description { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual Classified Classified { get; set; }
	}
}