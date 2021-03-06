using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class FrameType : AuditableEntity
	{
		public virtual int FrameTypeID { get; set; }

		[StringLength(100, MinimumLength = 0)]
		public string Title { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string Description { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual ICollection<InteriorFeature> InteriorFeatures { get; set; }
	}
}