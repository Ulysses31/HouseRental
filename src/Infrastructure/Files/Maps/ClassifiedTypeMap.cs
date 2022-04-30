using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class ClassifiedTypeMap : ClassMap<ClassifiedTypeDto>
	{
		public ClassifiedTypeMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}