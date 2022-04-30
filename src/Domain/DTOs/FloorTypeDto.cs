using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class FloorTypeDto : AuditableEntity, IMapFrom<FloorType>
	{
		public int FloorTypeID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }

		public ICollection<InteriorFeatureDto> InteriorFeatures { get; set; }
	}
}