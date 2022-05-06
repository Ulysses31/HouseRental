using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace CleanArchitecture.Application.UnitTests.Common.Mappings
{
	public class MappingTests
	{
		private readonly IConfigurationProvider _configuration;
		private readonly IMapper _mapper;

		public MappingTests()
		{
			_configuration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = _configuration.CreateMapper();
		}

		[Test]
		public void ShouldHaveValidConfiguration()
		{
			_configuration.AssertConfigurationIsValid();
		}

		[Test]
		[TestCase(typeof(Classified), typeof(ClassifiedDto))]
		[TestCase(typeof(AdvertiserInfo), typeof(AdvertiserInfoDto))]
		[TestCase(typeof(ClassifiedCharacteristics), typeof(ClassifiedCharacteristicsDto))]
		[TestCase(typeof(ClassifiedConstruction), typeof(ClassifiedConstructionDto))]
		[TestCase(typeof(ClassifiedPurpose), typeof(ClassifiedPurposeDto))]
		[TestCase(typeof(ClassifiedType), typeof(ClassifiedTypeDto))]
		[TestCase(typeof(EnergyClass), typeof(EnergyClassDto))]
		[TestCase(typeof(ExteriorFeature), typeof(ExteriorFeatureDto))]
		[TestCase(typeof(FloorNo), typeof(FloorNoDto))]
		[TestCase(typeof(FloorType), typeof(FloorTypeDto))]
		[TestCase(typeof(FrameType), typeof(FrameTypeDto))]
		[TestCase(typeof(GoogleMapPlace), typeof(GoogleMapPlaceDto))]
		[TestCase(typeof(HeatingSystem), typeof(HeatingSystemDto))]
		[TestCase(typeof(HeatingType), typeof(HeatingTypeDto))]
		[TestCase(typeof(InteriorFeature), typeof(InteriorFeatureDto))]
		[TestCase(typeof(Photos), typeof(PhotosDto))]
		[TestCase(typeof(PowerType), typeof(PowerTypeDto))]
		[TestCase(typeof(SuitableFor), typeof(SuitableForDto))]
		public void ShouldSupportMappingFromSourceToDestination(
			Type source,
			Type destination
		)
		{
			var instance = GetInstanceOf(destination);

			_mapper.Map(instance, source, destination);
		}

		private object GetInstanceOf(Type type)
		{
			if (type.GetConstructor(Type.EmptyTypes) != null)
				return Activator.CreateInstance(type);

			// Type without parameterless constructor
			return FormatterServices.GetUninitializedObject(type);
		}
	}
}