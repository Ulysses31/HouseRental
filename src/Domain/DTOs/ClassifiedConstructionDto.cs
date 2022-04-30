using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.DTOs
{
	public class ClassifiedConstructionDto : AuditableEntity, IMapFrom<ClassifiedConstruction>
	{
		public int ClassifiedConstructionID { get; set; }

		// Ρετιρέ
		public bool PentHouse { get; set; }

		// Νεόδμητο
		public bool NewlyBuilt { get; set; }

		// Ανακαινισμένο
		public bool Renovated { get; set; }

		// Χρήζει ανακαίνισης
		public bool NeedsToBeRenovated { get; set; }

		// Νεοκλασικό
		public bool NeoClassical { get; set; }

		// Διατηρητέο
		public bool Preserved { get; set; }

		// Ημιτελές
		public bool Incomplete { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public string Description { get; set; }

		public bool IsEnabled { get; set; }

		public bool IsDeleted { get; set; }

		public ClassifiedDto Classified { get; set; }
	}
}