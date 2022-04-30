using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.ClassifiedType
{
	/// <summary>
	/// IClassifiedTypeRepo interface
	/// </summary>
	public interface IClassifiedTypeRepo : IBaseRepo<ClassifiedTypeDto, ClassifiedTypeDto>
	{
		public Task<SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<ClassifiedTypeDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<ClassifiedTypeDto, object>> UpdateDtoById(
			int id,
			ClassifiedTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedTypeDto, object>> AddDto(
			ClassifiedTypeDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedTypeDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedTypeDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}