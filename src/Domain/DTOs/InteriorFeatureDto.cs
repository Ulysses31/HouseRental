using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.DTOs
{
	public class InteriorFeatureDto : AuditableEntity
	{
		public int InteriorFeaturesID { get; set; }

		// Ασανσέρ
		public bool Elevator { get; set; }

		// Εσωτερική σκάλα
		public bool InternalStaircase { get; set; }

		// Κλιματισμός
		public bool AirConditioning { get; set; }

		// Αποθήκη
		public bool Warehouse { get; set; }

		// Τύπος δαπέδων
		public int FloorTypeID { get; set; }

		public FloorTypeDto FloorType { get; set; }

		// Κατοικίδια ευπρόσδεκτα
		public bool PetsWelcome { get; set; }

		// Πόρτα ασφαλείας
		public bool SecurityDoor { get; set; }

		// Κουφώματα
		public int FrameTypeID { get; set; }

		public FrameTypeDto FrameType { get; set; }

		// Ρεύμα
		public int PowerTypeID { get; set; }

		public PowerTypeDto PowerType { get; set; }

		// Διπλά τζάμια
		public bool DoubleGlazing { get; set; }

		// Επιπλωμένο
		public bool Furnished { get; set; }

		// Τζάκι
		public bool Fireplace { get; set; }

		// Ενδοδαπέδια θέρμανση
		public bool UnderfloorHeating { get; set; }

		// Ηλιακός θερμοσίφωνας
		public bool SolarHeating { get; set; }

		// Νυχτερινό ρεύμα
		public bool NightCurrent { get; set; }

		// Σοφίτα
		public bool Garret { get; set; }

		// Playroom
		public bool Playroom { get; set; }

		// Δορυφορική κεραία
		public bool SatelliteAntenna { get; set; }

		// Συναγερμός
		public bool Alarm { get; set; }

		// Σίτες
		public bool DoorScreens { get; set; }

		// Διαμπερές
		public bool Airy { get; set; }

		// Βαμμένο
		public bool Painted { get; set; }

		// Με εξοπλισμό
		public bool WithEquipment { get; set; }

		// Καλωδιακή Τηλεόραση
		public bool CableTV { get; set; }

		// Καλωδίωση
		public bool Wiring { get; set; }

		// Ανελκυστήρας Φορτοεκφόρτωσης
		public bool LoadingUnloadingElevator { get; set; }

		// Ψευδοροφή
		public bool SuspendedCeiling { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public string Description { get; set; }

		public bool IsEnabled { get; set; }

		public bool IsDeleted { get; set; }

		public ClassifiedDto Classified { get; set; }
	}
}