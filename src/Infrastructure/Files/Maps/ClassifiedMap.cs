using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class ClassifiedMap : ClassMap<ClassifiedDto>
	{
		public ClassifiedMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}