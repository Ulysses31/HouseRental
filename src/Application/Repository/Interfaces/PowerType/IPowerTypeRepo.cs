using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.PowerType
{
	/// <summary>
	/// IPowerTypeRepo interface
	/// </summary>
	public interface IPowerTypeRepo : IBaseRepo<PowerTypeDto, PowerTypeDto>
	{
		public Task<SlApiResponse<PaginatedList<PowerTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<PowerTypeDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<PowerTypeDto, object>> UpdateDtoById(
			int id,
			PowerTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<PowerTypeDto, object>> AddDto(
			PowerTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<PowerTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<PowerTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}