using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class FloorNoMap : ClassMap<FloorNoDto>
	{
		public FloorNoMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}