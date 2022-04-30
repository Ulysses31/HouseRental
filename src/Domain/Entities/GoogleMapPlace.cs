using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class GoogleMapPlace : AuditableEntity
	{
		public virtual int GoogleMapPlaceID { get; set; }

		[StringLength(150, MinimumLength = 0)]
		public virtual string Area { get; set; }

		[StringLength(50, MinimumLength = 0)]
		public virtual string Latitude { get; set; }

		[StringLength(50, MinimumLength = 0)]
		public virtual string Longitude { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string Description { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual Classified Classified { get; set; }
	}
}