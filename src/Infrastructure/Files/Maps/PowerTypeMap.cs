using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class PowerTypeMap : ClassMap<PowerTypeDto>
	{
		public PowerTypeMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}