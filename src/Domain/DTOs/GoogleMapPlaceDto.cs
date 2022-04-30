using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;

namespace CleanArchitecture.Domain.DTOs
{
	public class GoogleMapPlaceDto : AuditableEntity, IMapFrom<GoogleMapPlace>
	{
		public int GoogleMapPlaceID { get; set; }
		public string Area { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Description { get; set; }
		public bool IsEnabled { get; set; }
		public bool IsDeleted { get; set; }
		public ClassifiedDto Classified { get; set; }
	}
}