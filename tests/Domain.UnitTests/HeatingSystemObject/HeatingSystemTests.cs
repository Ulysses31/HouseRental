using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.UnitTests.Helpers;
using NUnit.Framework;

namespace CleanArchitecture.Domain.UnitTests.HeatingSystemObject
{
	public class HeatingSystemTests
	{
		[Test]
		public void CheckObjects()
		{
			TestDomainEntitiestHelper.CompareObjects<HeatingSystem, HeatingSystemDto>();
		}

		[Test]
		public void CheckProperties()
		{
			TestDomainEntitiestHelper.CompareProperties<HeatingSystem, HeatingSystemDto>();
		}
	}
}