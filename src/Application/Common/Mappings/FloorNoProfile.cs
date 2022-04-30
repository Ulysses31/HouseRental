using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class FloorNoProfile : Profile
	{
		public FloorNoProfile()
		{
			CreateMap<FloorNo, FloorNoDto>().ReverseMap();
		}
	}
}