using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.FloorType
{
	/// <summary>
	/// IFloorTypeRepo interface
	/// </summary>
	public interface IFloorTypeRepo : IBaseRepo<FloorTypeDto, FloorTypeDto>
	{
		public Task<SlApiResponse<PaginatedList<FloorTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<FloorTypeDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<FloorTypeDto, object>> UpdateDtoById(
			int id,
			FloorTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FloorTypeDto, object>> AddDto(
			FloorTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FloorTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FloorTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}