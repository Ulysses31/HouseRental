using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class SuitableForProfile : Profile
	{
		public SuitableForProfile()
		{
			CreateMap<SuitableFor, SuitableForDto>().ReverseMap();
		}
	}
}