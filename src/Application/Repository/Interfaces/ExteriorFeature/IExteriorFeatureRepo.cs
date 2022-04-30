using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.ExteriorFeature
{
	/// <summary>
	/// IExteriorFeatureRepo interface
	/// </summary>
	public interface IExteriorFeatureRepo : IBaseRepo<ExteriorFeatureDto, ExteriorFeatureDto>
	{
		public Task<SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<ExteriorFeatureDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<ExteriorFeatureDto, object>> UpdateDtoById(
			int id,
			ExteriorFeatureDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ExteriorFeatureDto, object>> AddDto(
			ExteriorFeatureDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ExteriorFeatureDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ExteriorFeatureDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}