using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;

namespace CleanArchitecture.Domain.DTOs
{
	public class ClassifiedCharacteristicsDto : AuditableEntity, IMapFrom<ClassifiedCharacteristics>
	{
		public int CharacteristicsID { get; set; }

		// Τιμή
		public double Price { get; set; }

		// Τιμή ανά τ.μ.
		public double PricePerTm { get; set; }

		// Εμβαδόν
		public Int32 AreaTm { get; set; }

		// Εμβαδόν οικοπέδου
		public Int32 LandAreaTm { get; set; }

		// Επίπεδα
		public Int32 Levels { get; set; }

		// Τετραγωνικά
		public Int32 Square { get; set; }

		// Περιοχή
		public string Region { get; set; }

		// Κουζίνες
		public Int32 Cuisines { get; set; }

		// Μπάνια
		public Int32 Bathrooms { get; set; }

		// Υπνοδωμάτια
		public Int32 Bedrooms { get; set; }

		// Σύστημα θέρμανσης
		public int HeatingTypeID { get; set; }

		public HeatingTypeDto HeatingType { get; set; }

		public int HeatingSystemID { get; set; }

		public HeatingSystemDto HeatingSystem { get; set; }

		// Ενεργειακή κλάση
		public int EnergyClassID { get; set; }

		public EnergyClassDto EnergyClass { get; set; }

		// Έτος κατασκευής
		public Int32 ContructionYear { get; set; }

		// Εμβαδόν οικοπέδου
		public Int32 LandArea { get; set; }

		// Σαλόνια
		public Int32 Lounges { get; set; }

		// Μηνιαία κοινόχρηστα
		public double MonthlyShared { get; set; }

		// Απόσταση απο τη θάλασσα
		public double DistanceFromSea { get; set; }

		// Έτος ανακαίνισης
		public Int32 YearOfRenovation { get; set; }

		// Συντελεστής Δόμησης
		public double BuildingCoefficient { get; set; }

		// Κωδικός Συστήματος
		public string SystemCode { get; set; }

		// Κωδικός Ακινήτου
		public string PropertyCode { get; set; }

		// Διαθέσιμο από
		public DateTime? AvailableFrom { get; set; }

		// Δημοσίευση αγγελίας
		public DateTime? PublicationOfAdvert { get; set; }

		public string Description { get; set; }

		public bool IsEnabled { get; set; }

		public bool IsDeleted { get; set; }

		public ClassifiedDto Classified { get; set; }
	}
}