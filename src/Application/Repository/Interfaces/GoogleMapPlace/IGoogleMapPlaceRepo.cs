using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.GoogleMapPlace
{
	/// <summary>
	/// IGoogleMapPlaceRepo interface
	/// </summary>
	public interface IGoogleMapPlaceRepo : IBaseRepo<GoogleMapPlaceDto, GoogleMapPlaceDto>
	{
		public Task<SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<GoogleMapPlaceDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<GoogleMapPlaceDto, object>> UpdateDtoById(
			int id,
			GoogleMapPlaceDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<GoogleMapPlaceDto, object>> AddDto(
			GoogleMapPlaceDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<GoogleMapPlaceDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<GoogleMapPlaceDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}