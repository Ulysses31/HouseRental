using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.FloorNo
{
	/// <summary>
	/// IFloorNoRepo interface
	/// </summary>
	public interface IFloorNoRepo : IBaseRepo<FloorNoDto, FloorNoDto>
	{
		public Task<SlApiResponse<PaginatedList<FloorNoDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<FloorNoDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<FloorNoDto, object>> UpdateDtoById(
			int id,
			FloorNoDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FloorNoDto, object>> AddDto(
			FloorNoDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FloorNoDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FloorNoDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}