using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.InteriorFeature
{
	/// <summary>
	/// IInteriorFeatureRepo interface
	/// </summary>
	public interface IInteriorFeatureRepo : IBaseRepo<InteriorFeatureDto, InteriorFeatureDto>
	{
		public Task<SlApiResponse<PaginatedList<InteriorFeatureDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<InteriorFeatureDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<InteriorFeatureDto, object>> UpdateDtoById(
			int id,
			InteriorFeatureDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<InteriorFeatureDto, object>> AddDto(
			InteriorFeatureDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<InteriorFeatureDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<InteriorFeatureDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}