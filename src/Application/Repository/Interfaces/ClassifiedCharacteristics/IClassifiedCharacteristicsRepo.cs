using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.ClassifiedCharacteristics
{
	/// <summary>
	/// IClassifiedCharacteristicsRepo interface
	/// </summary>
	public interface IClassifiedCharacteristicsRepo : IBaseRepo<ClassifiedCharacteristicsDto, ClassifiedCharacteristicsDto>
	{
		public Task<SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> UpdateDtoById(
			int id,
			ClassifiedCharacteristicsDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> AddDto(
			ClassifiedCharacteristicsDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}