using CleanArchitecture.Application.Repository.Interfaces.AdvertiserInfo;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedCharacteristics;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedConstruction;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedPurpose;
using CleanArchitecture.Application.Repository.Interfaces.ClassifiedType;
using CleanArchitecture.Application.Repository.Interfaces.EnergyClass;
using CleanArchitecture.Application.Repository.Interfaces.ExteriorFeature;
using CleanArchitecture.Application.Repository.Interfaces.FloorNo;
using CleanArchitecture.Application.Repository.Interfaces.FloorType;
using CleanArchitecture.Application.Repository.Interfaces.FrameType;
using CleanArchitecture.Application.Repository.Interfaces.GoogleMapPlace;
using CleanArchitecture.Application.Repository.Interfaces.HeatingSystem;
using CleanArchitecture.Application.Repository.Interfaces.HeatingType;
using CleanArchitecture.Application.Repository.Interfaces.InteriorFeature;
using CleanArchitecture.Application.Repository.Interfaces.Photo;
using CleanArchitecture.Application.Repository.Interfaces.PowerType;
using CleanArchitecture.Application.Repository.Interfaces.SuitableFor;
using System;

namespace CleanArchitecture.Application.Repository.Interfaces
{
	/// <summary>
	/// IRepoManager interface
	/// </summary>
	public interface IRepoManager : IDisposable
	{
		/// <summary>
		/// IAdvertiserInfoRepo interface
		/// </summary>
		IAdvertiserInfoRepo AdvertiserInfoRepo { get; }

		/// <summary>
		/// IClassifiedCharacteristicsRepo interface
		/// </summary>
		IClassifiedCharacteristicsRepo ClassifiedCharacteristicsRepo { get; }

		/// <summary>
		/// IClassifiedConstructionRepo interface
		/// </summary>
		IClassifiedConstructionRepo ClassifiedConstructionRepo { get; }

		/// <summary>
		/// IClassifiedPurposeRepo interface
		/// </summary>
		IClassifiedPurposeRepo ClassifiedPurposeRepo { get; }

		/// <summary>
		/// IClassifiedTypeRepo interface
		/// </summary>
		IClassifiedTypeRepo ClassifiedTypeRepo { get; }

		/// <summary>
		/// IEnergyClassRepo interface
		/// </summary>
		IEnergyClassRepo EnergyClassRepo { get; }

		/// <summary>
		/// IExteriorFeatureRepo interface
		/// </summary>
		IExteriorFeatureRepo ExteriorFeatureRepo { get; }

		/// <summary>
		/// IFloorNoRepo interface
		/// </summary>
		IFloorNoRepo FloorNoRepo { get; }

		/// <summary>
		/// IFloorTypeRepo interface
		/// </summary>
		IFloorTypeRepo FloorTypeRepo { get; }

		/// <summary>
		/// IFrameTypeRepo interface
		/// </summary>
		IFrameTypeRepo FrameTypeRepo { get; }

		/// <summary>
		/// IGoogleMapPlaceRepo interface
		/// </summary>
		IGoogleMapPlaceRepo GoogleMapPlaceRepo { get; }

		/// <summary>
		/// IHeatingSystemRepo interface
		/// </summary>
		IHeatingSystemRepo HeatingSystemRepo { get; }

		/// <summary>
		/// IHeatingTypeRepo interface
		/// </summary>
		IHeatingTypeRepo HeatingTypeRepo { get; }

		/// <summary>
		/// IInteriorFeatureRepo interace
		/// </summary>
		IInteriorFeatureRepo InteriorFeatureRepo { get; }

		/// <summary>
		/// IPhotoRepo interface
		/// </summary>
		IPhotoRepo PhotoRepo { get; }

		/// <summary>
		/// PowerTypeRepo interface
		/// </summary>
		IPowerTypeRepo PowerTypeRepo { get; }

		/// <summary>
		/// ISuitableForRepo interface
		/// </summary>
		ISuitableForRepo SuitableForRepo { get; }
	}
}