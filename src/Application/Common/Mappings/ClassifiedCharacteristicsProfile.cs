using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class ClassifiedCharacteristicsProfile : Profile
	{
		public ClassifiedCharacteristicsProfile()
		{
			CreateMap<ClassifiedCharacteristics, ClassifiedCharacteristicsDto>().ReverseMap();
		}
	}
}