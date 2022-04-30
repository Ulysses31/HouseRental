using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class GoogleMapPlaceMap : ClassMap<GoogleMapPlaceDto>
	{
		public GoogleMapPlaceMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}