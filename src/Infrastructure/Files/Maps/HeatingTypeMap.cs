using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class HeatingTypeMap : ClassMap<HeatingTypeDto>
	{
		public HeatingTypeMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}