using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class HeatingTypeDto : AuditableEntity, IMapFrom<HeatingSystem>
	{
		public int HeatingTypeID { get; set; }
		public string HeatingTypeValue { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<ClassifiedCharacteristics> ClassifiedCharacteristics { get; set; }
	}
}