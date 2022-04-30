using CleanArchitecture.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
	public class InteriorFeature : AuditableEntity
	{
		public virtual int InteriorFeaturesID { get; set; }

		public virtual bool Elevator { get; set; }

		public virtual bool InternalStaircase { get; set; }

		public virtual bool AirConditioning { get; set; }

		public virtual bool Warehouse { get; set; }

		public virtual int FloorTypeID { get; set; }

		public virtual FloorType FloorType { get; set; }

		public virtual bool PetsWelcome { get; set; }

		public virtual bool SecurityDoor { get; set; }

		public virtual int FrameTypeID { get; set; }

		public virtual FrameType FrameType { get; set; }

		public virtual int PowerTypeID { get; set; }

		public virtual PowerType PowerType { get; set; }

		public virtual bool DoubleGlazing { get; set; }

		public virtual bool Furnished { get; set; }

		public virtual bool Fireplace { get; set; }

		public virtual bool UnderfloorHeating { get; set; }

		public virtual bool SolarHeating { get; set; }

		public virtual bool NightCurrent { get; set; }

		public virtual bool Garret { get; set; }

		public virtual bool Playroom { get; set; }

		public virtual bool SatelliteAntenna { get; set; }

		public virtual bool Alarm { get; set; }

		public virtual bool DoorScreens { get; set; }

		public virtual bool Airy { get; set; }

		public virtual bool Painted { get; set; }

		public virtual bool WithEquipment { get; set; }

		public virtual bool CableTV { get; set; }

		public virtual bool Wiring { get; set; }

		public virtual bool LoadingUnloadingElevator { get; set; }

		public virtual bool SuspendedCeiling { get; set; }

		[StringLength(255, MinimumLength = 0)]
		public virtual string Description { get; set; }

		public virtual bool IsEnabled { get; set; }

		public virtual bool IsDeleted { get; set; }

		public virtual Classified Classified { get; set; }
	}
}