using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class InteriorFeatureProfile : Profile
	{
		public InteriorFeatureProfile()
		{
			CreateMap<InteriorFeature, InteriorFeatureDto>().ReverseMap();
		}
	}
}