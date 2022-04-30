using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class SuitableForMap : ClassMap<SuitableForDto>
	{
		public SuitableForMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}