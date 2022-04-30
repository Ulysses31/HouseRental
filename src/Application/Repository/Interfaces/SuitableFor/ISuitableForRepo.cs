using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.SuitableFor
{
	/// <summary>
	/// ISuitableForRepo interface
	/// </summary>
	public interface ISuitableForRepo : IBaseRepo<SuitableForDto, SuitableForDto>
	{
		public Task<SlApiResponse<PaginatedList<SuitableForDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<SuitableForDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<SuitableForDto, object>> UpdateDtoById(
			int id,
			SuitableForDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<SuitableForDto, object>> AddDto(
			SuitableForDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<SuitableForDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<SuitableForDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}