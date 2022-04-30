using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class AdvertiserInfo : AuditableEntity
	{
		public virtual int AdvertiserInfoID { get; set; }

		[StringLength(20, MinimumLength = 0)]
		public virtual string Code { get; set; }

		[StringLength(150, MinimumLength = 0)]
		public virtual string Name { get; set; }

		[StringLength(150, MinimumLength = 0)]
		public virtual string Address { get; set; }

		[StringLength(150, MinimumLength = 0)]
		public virtual string Responsible { get; set; }

		[StringLength(15, MinimumLength = 15)]
		public virtual string Telephone { get; set; }

		[StringLength(100, MinimumLength = 0)]
		public virtual string Email { get; set; }

		[StringLength(150, MinimumLength = 0)]
		public virtual string Website { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual ICollection<Classified> Classifieds { get; set; }
	}
}