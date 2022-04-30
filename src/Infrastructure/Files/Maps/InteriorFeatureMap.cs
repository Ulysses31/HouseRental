using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class InteriorFeatureMap : ClassMap<InteriorFeatureDto>
	{
		public InteriorFeatureMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}