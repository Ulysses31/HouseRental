using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class Photos : AuditableEntity
	{
		public virtual int PhotoID { get; set; }

		public virtual int ClassifiedID { get; set; }

		public virtual Classified Classified { get; set; }

		[StringLength(100, MinimumLength = 0)]
		public virtual string FileName { get; set; }

		public virtual decimal FileSize { get; set; }

		public virtual byte[] FileContent { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }
	}
}