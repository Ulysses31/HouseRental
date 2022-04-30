using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class HeatingSystemProfile : Profile
	{
		public HeatingSystemProfile()
		{
			CreateMap<HeatingSystem, HeatingSystemDto>().ReverseMap();
		}
	}
}