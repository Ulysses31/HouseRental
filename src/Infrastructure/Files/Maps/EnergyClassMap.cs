using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class EnergyClassMap : ClassMap<EnergyClassDto>
	{
		public EnergyClassMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}