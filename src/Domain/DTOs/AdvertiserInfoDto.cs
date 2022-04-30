using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
	public class AdvertiserInfoDto : AuditableEntity, IMapFrom<AdvertiserInfo>
	{
		public int AdvertiserInfoID { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Responsible { get; set; }
		public string Telephone { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }
		public ICollection<ClassifiedDto> Classifieds { get; set; }
	}
}