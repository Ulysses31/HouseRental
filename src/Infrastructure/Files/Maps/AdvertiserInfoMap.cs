using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class AdvertiserInfoMap : ClassMap<AdvertiserInfoDto>
	{
		public AdvertiserInfoMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}