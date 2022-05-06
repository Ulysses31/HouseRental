using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.UnitTests.Helpers;
using NUnit.Framework;

namespace CleanArchitecture.Domain.UnitTests.GoogleMapPlaceObject
{
	public class GoogleMapPlaceTests
	{
		[Test]
		public void CheckObjects()
		{
			TestDomainEntitiestHelper.CompareObjects<GoogleMapPlace, GoogleMapPlaceDto>();
		}

		[Test]
		public void CheckProperties()
		{
			TestDomainEntitiestHelper.CompareProperties<GoogleMapPlace, GoogleMapPlaceDto>();
		}
	}
}