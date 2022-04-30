using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class ClassifiedPurposeProfile : Profile
	{
		public ClassifiedPurposeProfile()
		{
			CreateMap<ClassifiedPurpose, ClassifiedPurposeDto>().ReverseMap();
		}
	}
}