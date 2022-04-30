using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Domain.DTOs
{
	public class SuitableForDto : AuditableEntity, IMapFrom<SuitableFor>
	{
		public int SuitableForID { get; set; }

		// Φοιτητικό
		public bool StudentUse { get; set; }

		// Εξοχικό
		public bool HolidayHomeUse { get; set; }

		// Επαγγελματική χρήση
		public bool ProfessionalUse { get; set; }

		// Επενδυτικό
		public bool InvestmentUse { get; set; }

		// Tουριστική ενοικίαση
		public bool TouristRentalUse { get; set; }

		public string Description { get; set; }

		public bool IsEnabled { get; set; }

		public bool IsDeleted { get; set; }

		public ClassifiedDto Classified { get; set; }
	}
}