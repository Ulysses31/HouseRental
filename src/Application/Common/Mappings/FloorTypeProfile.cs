using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class FloorTypeProfile : Profile
	{
		public FloorTypeProfile()
		{
			CreateMap<FloorType, FloorTypeDto>().ReverseMap();
		}
	}
}