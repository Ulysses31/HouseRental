using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.FrameType
{
	/// <summary>
	/// IFrameTypeRepo interface
	/// </summary>
	public interface IFrameTypeRepo : IBaseRepo<FrameTypeDto, FrameTypeDto>
	{
		public Task<SlApiResponse<PaginatedList<FrameTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<FrameTypeDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<FrameTypeDto, object>> UpdateDtoById(
			int id,
			FrameTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FrameTypeDto, object>> AddDto(
			FrameTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FrameTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<FrameTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}