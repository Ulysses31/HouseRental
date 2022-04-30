using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class FrameTypeProfile : Profile
	{
		public FrameTypeProfile()
		{
			CreateMap<FrameType, FrameTypeDto>().ReverseMap();
		}
	}
}