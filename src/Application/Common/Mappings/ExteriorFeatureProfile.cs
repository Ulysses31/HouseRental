using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class ExteriorFeatureProfile : Profile
	{
		public ExteriorFeatureProfile()
		{
			CreateMap<ExteriorFeature, ExteriorFeatureDto>().ReverseMap();
		}
	}
}