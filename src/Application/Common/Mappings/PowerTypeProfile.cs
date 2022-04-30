using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class PowerTypeProfile : Profile
	{
		public PowerTypeProfile()
		{
			CreateMap<PowerType, PowerTypeDto>().ReverseMap();
		}
	}
}