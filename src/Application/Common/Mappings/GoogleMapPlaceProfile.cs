using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class GoogleMapPlaceProfile : Profile
	{
		public GoogleMapPlaceProfile()
		{
			CreateMap<GoogleMapPlace, GoogleMapPlaceDto>().ReverseMap();
		}
	}
}