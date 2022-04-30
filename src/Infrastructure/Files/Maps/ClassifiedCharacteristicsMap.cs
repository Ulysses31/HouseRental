using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class ClassifiedCharacteristicsMap : ClassMap<ClassifiedCharacteristicsDto>
	{
		public ClassifiedCharacteristicsMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}