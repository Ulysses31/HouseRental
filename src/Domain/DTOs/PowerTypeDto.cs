using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class PowerTypeDto : AuditableEntity
	{
		public int PowerTypeID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }

		public ICollection<InteriorFeatureDto> InteriorFeatures { get; set; }
	}
}