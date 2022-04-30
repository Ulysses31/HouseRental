using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class ClassifiedConstructionProfile : Profile
	{
		public ClassifiedConstructionProfile()
		{
			CreateMap<ClassifiedConstruction, ClassifiedConstructionDto>().ReverseMap();
		}
	}
}