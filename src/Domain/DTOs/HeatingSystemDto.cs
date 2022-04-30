using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class HeatingSystemDto : AuditableEntity, IMapFrom<HeatingSystem>
	{
		public int HeatingSystemID { get; set; }
		public string HeatingSystemValue { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<ClassifiedCharacteristicsDto> ClassifiedCharacteristics { get; set; }
	}
}