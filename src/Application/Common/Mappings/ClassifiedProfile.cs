using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class ClassifiedProfile : Profile
	{
		public ClassifiedProfile()
		{
			CreateMap<Classified, ClassifiedDto>().ReverseMap();
		}
	}
}