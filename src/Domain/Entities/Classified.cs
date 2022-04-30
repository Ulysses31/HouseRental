using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class Classified : AuditableEntity
	{
		public virtual int ClassifiedID { get; set; }

		public virtual int PurposeID { get; set; }

		public virtual ClassifiedPurpose ClassifiedPurpose { get; set; }

		public virtual int TypeID { get; set; }

		public virtual ClassifiedType ClassifiedType { get; set; }

		public virtual int GoogleMapPlaceID { get; set; }

		public virtual GoogleMapPlace GoogleMapPlace { get; set; }

		public virtual int AdvertiserInfoID { get; set; }

		public virtual AdvertiserInfo AdvertiserInfo { get; set; }

		public virtual int SuitableForID { get; set; }

		public virtual SuitableFor SuitableFor { get; set; }

		public virtual int ClassifiedConstructionID { get; set; }

		public virtual ClassifiedConstruction ClassifiedConstruction { get; set; }

		public virtual int ExteriorFeaturesID { get; set; }

		public virtual ExteriorFeature ExteriorFeature { get; set; }

		public virtual int InteriorFeaturesID { get; set; }

		public virtual InteriorFeature InteriorFeature { get; set; }

		public virtual int FloorNoID { get; set; }

		public virtual FloorNo FloorNo { get; set; }

		public virtual int CharacteristicsID { get; set; }
		
		public virtual ClassifiedCharacteristics ClassifiedCharacteristics { get; set; }

		public virtual ICollection<Photos> Photos { get; set; }

		[StringLength(150, MinimumLength = 0)]
		public virtual string ClassifiedTitle { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string ClassifiedDesription { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }
	}
}