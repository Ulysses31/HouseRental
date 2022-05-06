using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.UnitTests.Helpers;
using NUnit.Framework;

namespace CleanArchitecture.Domain.UnitTests.ClassifiedTypeObject
{
	public class ClassifiedTypeTests
	{
		[Test]
		public void CheckObjects()
		{
			TestDomainEntitiestHelper.CompareObjects<ClassifiedType, ClassifiedTypeDto>();
		}

		[Test]
		public void CheckProperties()
		{
			TestDomainEntitiestHelper.CompareProperties<ClassifiedType, ClassifiedTypeDto>();
		}
	}
}