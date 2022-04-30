using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class ExteriorFeatureMap : ClassMap<ExteriorFeatureDto>
	{
		public ExteriorFeatureMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}