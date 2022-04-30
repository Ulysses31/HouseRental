using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.HeatingSystem
{
	/// <summary>
	/// IHeatingSystemRepo interface
	/// </summary>
	public interface IHeatingSystemRepo : IBaseRepo<HeatingSystemDto, HeatingSystemDto>
	{
		public Task<SlApiResponse<PaginatedList<HeatingSystemDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<HeatingSystemDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<HeatingSystemDto, object>> UpdateDtoById(
			int id,
			HeatingSystemDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<HeatingSystemDto, object>> AddDto(
			HeatingSystemDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<HeatingSystemDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<HeatingSystemDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}