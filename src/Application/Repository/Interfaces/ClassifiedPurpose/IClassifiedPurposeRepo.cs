using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.ClassifiedPurpose
{
	/// <summary>
	/// IClassifiedPurposeRepo interface
	/// </summary>
	public interface IClassifiedPurposeRepo : IBaseRepo<ClassifiedPurposeDto, ClassifiedPurposeDto>
	{
		public Task<SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<ClassifiedPurposeDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<ClassifiedPurposeDto, object>> UpdateDtoById(
			int id,
			ClassifiedPurposeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedPurposeDto, object>> AddDto(
			ClassifiedPurposeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedPurposeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedPurposeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}