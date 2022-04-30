using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class FloorNoDto : AuditableEntity, IMapFrom<FloorNo>
	{
		public int FloorNoID { get; set; }
		public string FloorNoValue { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<ClassifiedDto> Classifieds { get; set; }
	}
}