using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Services;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Services;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Services;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Services;
using CleanArchitecture.Application.MediatR.ClassifiedType.Services;
using CleanArchitecture.Application.MediatR.EnergyClass.Services;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Services;
using CleanArchitecture.Application.MediatR.FloorNo.Services;
using CleanArchitecture.Application.MediatR.FloorType.Services;
using CleanArchitecture.Application.MediatR.FrameType.Services;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Services;
using CleanArchitecture.Application.MediatR.HeatingSystem.Services;
using CleanArchitecture.Application.Repository.AdvertiserInfo;
using CleanArchitecture.Application.Repository.ClassifiedCharacteristics;
using CleanArchitecture.Application.Repository.ClassifiedConstruction;
using CleanArchitecture.Application.Repository.ClassifiedPurpose;
using CleanArchitecture.Application.Repository.ClassifiedType;
using CleanArchitecture.Application.Repository.EnergyClass;
using CleanArchitecture.Application.Repository.ExteriorFeature;
using CleanArchitecture.Application.Repository.FloorNo;
using CleanArchitecture.Application.Repository.FloorType;
using CleanArchitecture.Application.Repository.FrameType;
using CleanArchitecture.Application.Repository.GoogleMapPlace;
using CleanArchitecture.Application.Repository.HeatingSystem;
using CleanArchitecture.Application.Repository.Interfaces;
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
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace CleanArchitecture.Application.Repository
{
	public class RepoManager : IRepoManager
	{
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;
		private readonly IHttpClientFactory httpClientFactory;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly AdvertiserInfoService advertiserInfoService;
		private readonly ClassifiedCharacteristicsService classifiedCharacteristicsService;
		private readonly ClassifiedConstructionService classifiedConstructionService;
		private readonly ClassifiedPurposeService classifiedPurposeService;
		private readonly ClassifiedTypeService classifiedTypeService;
		private readonly EnergyClassService energyClassService;
		private readonly ExteriorFeatureService exteriorFeatureService;
		private readonly FloorNoService floorNoService;
		private readonly FloorTypeService floorTypeService;
		private readonly FrameTypeService frameTypeService;
		private readonly HeatingSystemService heatingSystemService;
		private readonly GoogleMapPlaceService googleMapPlaceService;

		private readonly SlApiResponse<PaginatedList<AdvertiserInfoDto>, object> advertiseInfoResponseList;
		private readonly SlApiResponse<AdvertiserInfoDto, object> advertiseInfoResponse;
		private readonly SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object> classifiedCharacteristicsResponseList;
		private readonly SlApiResponse<ClassifiedCharacteristicsDto, object> classifiedCharacteristicsResponse;
		private readonly SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object> classifiedConstructionResponseList;
		private readonly SlApiResponse<ClassifiedConstructionDto, object> classifiedConstructionResponse;
		private readonly SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object> classifiedPurposeResponseList;
		private readonly SlApiResponse<ClassifiedPurposeDto, object> classifiedPurposeResponse;
		private readonly SlApiResponse<PaginatedList<ClassifiedTypeDto>, object> classifiedTypeResponseList;
		private readonly SlApiResponse<ClassifiedTypeDto, object> classifiedTypeResponse;
		private readonly SlApiResponse<PaginatedList<EnergyClassDto>, object> energyClassResponseList;
		private readonly SlApiResponse<EnergyClassDto, object> energyClassResponse;
		private readonly SlApiResponse<PaginatedList<ExteriorFeatureDto>, object> exteriorFeatureResponseList;
		private readonly SlApiResponse<ExteriorFeatureDto, object> exteriorFeatureResponse;
		private readonly SlApiResponse<PaginatedList<FloorNoDto>, object> floorNoResponseList;
		private readonly SlApiResponse<FloorNoDto, object> floorNoResponse;
		private readonly SlApiResponse<PaginatedList<FloorTypeDto>, object> floorTypeResponseList;
		private readonly SlApiResponse<FloorTypeDto, object> floorTypeResponse;
		private readonly SlApiResponse<PaginatedList<FrameTypeDto>, object> frameTypeResponseList;
		private readonly SlApiResponse<FrameTypeDto, object> frameTypeResponse;
		private readonly SlApiResponse<PaginatedList<HeatingSystemDto>, object> heatingSystemResponseList;
		private readonly SlApiResponse<HeatingSystemDto, object> heatingSystemResponse;
		private readonly SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object> googleMapPlaceResponseList;
		private readonly SlApiResponse<GoogleMapPlaceDto, object> googleMapPlaceResponse;

		private IAdvertiserInfoRepo _advertiserInfoRepo;
		private IClassifiedCharacteristicsRepo _classifiedCharacteristicsRepo;
		private IClassifiedConstructionRepo _classifiedConstructionRepo;
		private IClassifiedPurposeRepo _classifiedPurposeRepo;
		private IClassifiedTypeRepo _classifiedTypeRepo;
		private IEnergyClassRepo _energyClassRepo;
		private IExteriorFeatureRepo _exteriorFeatureRepo;
		private IFloorNoRepo _floorNoRepo;
		private IFloorTypeRepo _floorTypeRepo;
		private IFrameTypeRepo _frameTypeRepo;
		private IGoogleMapPlaceRepo _googleMapPlaceRepo;
		private IHeatingSystemRepo _heatingSystemRepo;

		public RepoManager(
			IMapper mapper,
			IConfiguration configuration,
			IHttpClientFactory httpClientFactory,
			IHttpContextAccessor httpContextAccessor,

			AdvertiserInfoService advertiserInfoService,
			ClassifiedCharacteristicsService classifiedCharacteristicsService,
			ClassifiedConstructionService classifiedConstructionService,
			ClassifiedPurposeService classifiedPurposeService,
			ClassifiedTypeService classifiedTypeService,
			EnergyClassService energyClassService,
			ExteriorFeatureService exteriorFeatureService,
			FloorNoService floorNoService,
			FloorTypeService floorTypeService,
			FrameTypeService frameTypeService,
			HeatingSystemService heatingSystemService,

			SlApiResponse<PaginatedList<AdvertiserInfoDto>, object> advertiseInfoResponseList,
			SlApiResponse<AdvertiserInfoDto, object> advertiseInfoResponse,
			SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object> classifiedCharacteristicsResponseList,
			SlApiResponse<ClassifiedCharacteristicsDto, object> classifiedCharacteristicsResponse,
			SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object> classifiedConstructionResponseList,
			SlApiResponse<ClassifiedConstructionDto, object> classifiedConstructionResponse,
			SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object> classifiedPurposeResponseList,
			SlApiResponse<ClassifiedPurposeDto, object> classifiedPurposeResponse,
			SlApiResponse<PaginatedList<ClassifiedTypeDto>, object> classifiedTypeResponseList,
			SlApiResponse<ClassifiedTypeDto, object> classifiedTypeResponse,
			SlApiResponse<PaginatedList<EnergyClassDto>, object> energyClassResponseList,
			SlApiResponse<EnergyClassDto, object> energyClassResponse,
			SlApiResponse<PaginatedList<ExteriorFeatureDto>, object> exteriorFeatureResponseList,
			SlApiResponse<ExteriorFeatureDto, object> exteriorFeatureResponse,
			SlApiResponse<PaginatedList<FloorNoDto>, object> floorNoResponseList,
			SlApiResponse<FloorNoDto, object> floorNoResponse,
			SlApiResponse<PaginatedList<FloorTypeDto>, object> floorTypeResponseList,
			SlApiResponse<FloorTypeDto, object> floorTypeResponse,
			SlApiResponse<PaginatedList<FrameTypeDto>, object> frameTypeResponseList,
			SlApiResponse<FrameTypeDto, object> frameTypeResponse,
			SlApiResponse<PaginatedList<HeatingSystemDto>, object> heatingSystemResponseList,
			SlApiResponse<HeatingSystemDto, object> heatingSystemResponse
, GoogleMapPlaceService googleMapPlaceService, SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object> googleMapPlaceResponseList, SlApiResponse<GoogleMapPlaceDto, object> googleMapPlaceResponse)
		{
			this.mapper = mapper;
			this.configuration = configuration;
			this.httpClientFactory = httpClientFactory;
			this.httpContextAccessor = httpContextAccessor;
			this.advertiserInfoService = advertiserInfoService;
			this.classifiedCharacteristicsService = classifiedCharacteristicsService;
			this.classifiedConstructionService = classifiedConstructionService;
			this.classifiedPurposeService = classifiedPurposeService;
			this.classifiedTypeService = classifiedTypeService;
			this.energyClassService = energyClassService;
			this.exteriorFeatureService = exteriorFeatureService;
			this.floorNoService = floorNoService;
			this.floorTypeService = floorTypeService;
			this.frameTypeService = frameTypeService;
			this.heatingSystemService = heatingSystemService;
			this.advertiseInfoResponseList = advertiseInfoResponseList;
			this.advertiseInfoResponse = advertiseInfoResponse;
			this.classifiedCharacteristicsResponseList = classifiedCharacteristicsResponseList;
			this.classifiedCharacteristicsResponse = classifiedCharacteristicsResponse;
			this.classifiedConstructionResponseList = classifiedConstructionResponseList;
			this.classifiedConstructionResponse = classifiedConstructionResponse;
			this.classifiedPurposeResponseList = classifiedPurposeResponseList;
			this.classifiedPurposeResponse = classifiedPurposeResponse;
			this.classifiedTypeResponseList = classifiedTypeResponseList;
			this.classifiedTypeResponse = classifiedTypeResponse;
			this.energyClassResponseList = energyClassResponseList;
			this.energyClassResponse = energyClassResponse;
			this.exteriorFeatureResponseList = exteriorFeatureResponseList;
			this.exteriorFeatureResponse = exteriorFeatureResponse;
			this.floorNoResponseList = floorNoResponseList;
			this.floorNoResponse = floorNoResponse;
			this.floorTypeResponseList = floorTypeResponseList;
			this.floorTypeResponse = floorTypeResponse;
			this.frameTypeResponseList = frameTypeResponseList;
			this.frameTypeResponse = frameTypeResponse;
			this.heatingSystemResponseList = heatingSystemResponseList;
			this.heatingSystemResponse = heatingSystemResponse;
			this.googleMapPlaceService = googleMapPlaceService;
			this.googleMapPlaceResponseList = googleMapPlaceResponseList;
			this.googleMapPlaceResponse = googleMapPlaceResponse;
		}

		public IAdvertiserInfoRepo AdvertiserInfoRepo => _advertiserInfoRepo = _advertiserInfoRepo
			?? new AdvertiserInfoRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				advertiserInfoService,
				advertiseInfoResponseList,
				advertiseInfoResponse
			);

		public IClassifiedCharacteristicsRepo ClassifiedCharacteristicsRepo => _classifiedCharacteristicsRepo = _classifiedCharacteristicsRepo
			?? new ClassifiedCharacteristicsRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				classifiedCharacteristicsService,
				classifiedCharacteristicsResponseList,
				classifiedCharacteristicsResponse
			);

		public IClassifiedConstructionRepo ClassifiedConstructionRepo => _classifiedConstructionRepo = _classifiedConstructionRepo
			?? new ClassifiedConstructionRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				classifiedConstructionService,
				classifiedConstructionResponseList,
				classifiedConstructionResponse
		);

		public IClassifiedPurposeRepo ClassifiedPurposeRepo => _classifiedPurposeRepo = _classifiedPurposeRepo
			?? new ClassifiedPurposeRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				classifiedPurposeService,
				classifiedPurposeResponseList,
				classifiedPurposeResponse
			);

		public IClassifiedTypeRepo ClassifiedTypeRepo => _classifiedTypeRepo = _classifiedTypeRepo
			?? new ClassifiedTypeRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				classifiedTypeService,
				classifiedTypeResponseList,
				classifiedTypeResponse
			);

		public IEnergyClassRepo EnergyClassRepo => _energyClassRepo = _energyClassRepo
			?? new EnergyClassRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				energyClassService,
				energyClassResponseList,
				energyClassResponse
			);

		public IExteriorFeatureRepo ExteriorFeatureRepo => _exteriorFeatureRepo = _exteriorFeatureRepo
			?? new ExteriorFeatureRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				exteriorFeatureService,
				exteriorFeatureResponseList,
				exteriorFeatureResponse
			);

		public IFloorNoRepo FloorNoRepo => _floorNoRepo = _floorNoRepo
			?? new FloorNoRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				floorNoService,
				floorNoResponseList,
				floorNoResponse
			);

		public IFloorTypeRepo FloorTypeRepo => _floorTypeRepo = _floorTypeRepo
			?? new FloorTypeRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				floorTypeService,
				floorTypeResponseList,
				floorTypeResponse
			);

		public IFrameTypeRepo FrameTypeRepo => _frameTypeRepo = _frameTypeRepo
			?? new FrameTypeRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				frameTypeService,
				frameTypeResponseList,
				frameTypeResponse
			);

		public IGoogleMapPlaceRepo GoogleMapPlaceRepo => _googleMapPlaceRepo = _googleMapPlaceRepo
			?? new GoogleMapPlaceRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				googleMapPlaceService,
				googleMapPlaceResponseList,
				googleMapPlaceResponse
			);

		public IHeatingSystemRepo HeatingSystemRepo => _heatingSystemRepo = _heatingSystemRepo
			?? new HeatingSystemRepo(
				mapper,
				configuration,
				httpClientFactory,
				httpContextAccessor,
				heatingSystemService,
				heatingSystemResponseList,
				heatingSystemResponse
			);

		public void Dispose()
		{
		}
	}
}