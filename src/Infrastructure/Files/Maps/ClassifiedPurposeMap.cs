using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class ClassifiedPurposeMap : ClassMap<ClassifiedPurposeDto>
	{
		public ClassifiedPurposeMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}