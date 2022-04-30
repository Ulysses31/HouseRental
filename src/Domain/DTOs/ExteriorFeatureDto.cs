using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.DTOs
{
	public class ExteriorFeatureDto : AuditableEntity, IMapFrom<ExteriorFeature>
	{
		public int ExteriorFeaturesID { get; set; }

		// Θέα
		public bool PropertyView { get; set; }

		// Πρόσοψεως
		public bool Facade { get; set; }

		// Προσανατολισμός
		[StringLength(100, MinimumLength = 0)]
		public string Orientation { get; set; }

		// Πρόσβαση από
		[StringLength(100, MinimumLength = 0)]
		public string AccessFrom { get; set; }

		// Οικιστική ζώνη
		public bool ResidentialZone { get; set; }

		// Θέση Στάθμευσης
		public bool ParkingSpot { get; set; }

		// Τέντες
		public bool Awnings { get; set; }

		// Κήπος
		public bool Garden { get; set; }

		// Πρόσβάση για ΑμεΑ
		public bool DisabledAccess { get; set; }

		// Πισίνα
		public bool Pool { get; set; }

		// Γωνιακό
		public bool Corner { get; set; }

		// Βεράντα
		public bool Veranda { get; set; }

		// Μήκος Βιτρίνας
		public Int32? ShowcaseGlassLength { get; set; }

		// Ράμπα εκφόρτωσης
		public bool? UnloadingRamp { get; set; }

		// Εντός σχεδίου πόλης
		public bool WithinCityPlan { get; set; }

		// Συντελεστής δόμησης
		public double StructureFactor { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public string Description { get; set; }

		public bool IsEnabled { get; set; }

		public bool IsDeleted { get; set; }

		public ClassifiedDto Classified { get; set; }
	}
}