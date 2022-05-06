using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.UnitTests.Helpers;
using NUnit.Framework;

namespace CleanArchitecture.Domain.UnitTests.ClassifiedObject
{
	public class ClassifiedTests
	{
		[Test]
		public void CheckObjects()
		{
			TestDomainEntitiestHelper.CompareObjects<Classified, ClassifiedDto>();
		}

		[Test]
		public void CheckProperties()
		{
			TestDomainEntitiestHelper.CompareProperties<Classified, ClassifiedDto>();
		}
	}
}