using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class FloorTypeMap : ClassMap<FloorTypeDto>
	{
		public FloorTypeMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}