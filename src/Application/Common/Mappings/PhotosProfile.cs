using AutoMapper;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Mappings
{
	public class PhotosProfile : Profile
	{
		public PhotosProfile()
		{
			CreateMap<Photos, PhotosDto>().ReverseMap();
		}
	}
}