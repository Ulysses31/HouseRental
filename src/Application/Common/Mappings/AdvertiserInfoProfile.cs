using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class AdvertiserInfoProfile : Profile
	{
		public AdvertiserInfoProfile()
		{
			CreateMap<AdvertiserInfo, AdvertiserInfoDto>().ReverseMap();
		}
	}
}