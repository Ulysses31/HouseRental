using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class EnergyClassDto : AuditableEntity, IMapFrom<EnergyClass>
	{
		public int EnergyClassID { get; set; }
		public string EnergyClassValue { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }

		public virtual ICollection<ClassifiedCharacteristicsDto> ClassifiedCharacteristics { get; set; }
	}
}