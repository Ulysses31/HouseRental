using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class ClassifiedConstructionMap : ClassMap<ClassifiedConstructionDto>
	{
		public ClassifiedConstructionMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}