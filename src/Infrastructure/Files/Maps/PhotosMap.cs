using CleanArchitecture.Domain.DTOs;
using CsvHelper.Configuration;
using System.Globalization;

namespace CleanArchitecture.Infrastructure.Files.Maps
{
	public class PhotosMap : ClassMap<PhotosDto>
	{
		public PhotosMap()
		{
			AutoMap(CultureInfo.InvariantCulture);
		}
	}
}