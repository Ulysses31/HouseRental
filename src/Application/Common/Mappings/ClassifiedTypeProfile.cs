using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class ClassifiedTypeProfile : Profile
	{
		public ClassifiedTypeProfile()
		{
			CreateMap<ClassifiedType, ClassifiedTypeDto>().ReverseMap();
		}
	}
}