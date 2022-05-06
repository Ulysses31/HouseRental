using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.UnitTests.Helpers;
using NUnit.Framework;

namespace CleanArchitecture.Domain.UnitTests.FloorNoObject
{
	public class FloorNoTests
	{
		[Test]
		public void CheckObjects()
		{
			TestDomainEntitiestHelper.CompareObjects<FloorNo, FloorNoDto>();
		}

		[Test]
		public void CheckProperties()
		{
			TestDomainEntitiestHelper.CompareProperties<FloorNo, FloorNoDto>();
		}
	}
}