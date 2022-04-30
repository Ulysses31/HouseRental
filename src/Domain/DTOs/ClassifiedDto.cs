using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class ClassifiedDto : AuditableEntity, IMapFrom<Classified>
	{
		public int ClassifiedID { get; set; }
		public int PurposeID { get; set; }
		public ClassifiedPurposeDto ClassifiedPurpose { get; set; }
		public int TypeID { get; set; }
		public ClassifiedTypeDto ClassifiedType { get; set; }
		public int ExteriorFeaturesID { get; set; }
		public ExteriorFeatureDto ExteriorFeature { get; set; }
		public int InteriorFeaturesID { get; set; }
		public InteriorFeatureDto InteriorFeature { get; set; }
		public int GoogleMapPlaceID { get; set; }
		public GoogleMapPlaceDto GoogleMapPlace { get; set; }
		public int AdvertiserInfoID { get; set; }
		public AdvertiserInfoDto AdvertiserInfo { get; set; }
		public int SuitableForID { get; set; }
		public SuitableForDto SuitableFor { get; set; }
		public int FloorNoID { get; set; }
		public FloorNoDto FloorNo { get; set; }
		public int CharacteristicsID { get; set; }
		public ClassifiedCharacteristicsDto ClassifiedCharacteristics { get; set; }
		public ICollection<PhotosDto> Photos { get; set; }
		public string ClassifiedTitle { get; set; }
		public string ClassifiedDesription { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }
	}
}