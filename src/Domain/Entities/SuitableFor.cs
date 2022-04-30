using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class SuitableFor : AuditableEntity
	{
		public virtual int SuitableForID { get; set; }

		public virtual bool StudentUse { get; set; }

		public virtual bool HolidayHomeUse { get; set; }

		public virtual bool ProfessionalUse { get; set; }

		public virtual bool InvestmentUse { get; set; }

		public virtual bool TouristRentalUse { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string Description { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual Classified Classified { get; set; }
	}
}