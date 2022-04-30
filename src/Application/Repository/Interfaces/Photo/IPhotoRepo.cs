using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.Photo
{
	/// <summary>
	/// IPhotoRepo interface
	/// </summary>
	public interface IPhotoRepo : IBaseRepo<PhotosDto, PhotosDto>
	{
		public Task<SlApiResponse<PaginatedList<PhotosDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<PhotosDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<PhotosDto, object>> UpdateDtoById(
			int id,
			PhotosDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<PhotosDto, object>> AddDto(
			PhotosDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<PhotosDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<PhotosDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}