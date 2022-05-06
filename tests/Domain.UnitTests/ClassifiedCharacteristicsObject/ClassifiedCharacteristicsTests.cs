using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.UnitTests.Helpers;
using NUnit.Framework;

namespace CleanArchitecture.Domain.UnitTests.ClassifiedCharacteristicsObject
{
	public class ClassifiedCharacteristicsTests
	{
		[Test]
		public void CheckObjects()
		{
			TestDomainEntitiestHelper.CompareObjects<ClassifiedCharacteristics, ClassifiedCharacteristicsDto>();
		}

		[Test]
		public void CheckProperties()
		{
			TestDomainEntitiestHelper.CompareProperties<ClassifiedCharacteristics, ClassifiedCharacteristicsDto>();
		}
	}
}