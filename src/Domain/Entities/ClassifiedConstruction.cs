using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class ClassifiedConstruction : AuditableEntity
	{
		public virtual int ClassifiedConstructionID { get; set; }

		public virtual bool PentHouse { get; set; }
		
		public virtual bool NewlyBuilt { get; set; }
		
		public virtual bool Renovated { get; set; }
		
		public virtual bool NeedsToBeRenovated { get; set; }
		
		public virtual bool NeoClassical { get; set; }
		
		public virtual bool Preserved { get; set; }
		
		public virtual bool Incomplete { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string Description { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual Classified Classified { get; set; }
	}
}