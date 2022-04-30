using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.ClassifiedConstruction
{
	/// <summary>
	/// IClassifiedConstructionRepo interface
	/// </summary>
	public interface IClassifiedConstructionRepo : IBaseRepo<ClassifiedConstructionDto, ClassifiedConstructionDto>
	{
		public Task<SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<ClassifiedConstructionDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<ClassifiedConstructionDto, object>> UpdateDtoById(
			int id,
			ClassifiedConstructionDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedConstructionDto, object>> AddDto(
			ClassifiedConstructionDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedConstructionDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedConstructionDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}