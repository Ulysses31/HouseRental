using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.HeatingType
{
	/// <summary>
	/// IHeatingTypeRepo interface
	/// </summary>
	public interface IHeatingTypeRepo : IBaseRepo<HeatingTypeDto, HeatingTypeDto>
	{
		public Task<SlApiResponse<PaginatedList<HeatingTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<HeatingTypeDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<HeatingTypeDto, object>> UpdateDtoById(
			int id,
			HeatingTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<HeatingTypeDto, object>> AddDto(
			HeatingTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<HeatingTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<HeatingTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}