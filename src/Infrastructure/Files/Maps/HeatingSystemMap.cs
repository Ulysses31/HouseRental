using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class HeatingSystemMap : ClassMap<HeatingSystemDto>
	{
		public HeatingSystemMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}