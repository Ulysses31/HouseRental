using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class EnergyClassProfile : Profile
	{
		public EnergyClassProfile()
		{
			CreateMap<EnergyClass, EnergyClassDto>().ReverseMap();
		}
	}
}