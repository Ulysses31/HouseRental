using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.AdvertiserInfo
{
	/// <summary>
	/// IAdvertiserInfoRepo interface
	/// </summary>
	public interface IAdvertiserInfoRepo : IBaseRepo<AdvertiserInfoDto, AdvertiserInfoDto>
	{
		public Task<SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>> GetAllWithPagination(
				[FromQuery] SlApiPaginationQuery query
		);

		public Task<SlApiResponse<AdvertiserInfoDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<AdvertiserInfoDto, object>> UpdateDtoById(
			int id,
			AdvertiserInfoDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<AdvertiserInfoDto, object>> AddDto(
			AdvertiserInfoDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<AdvertiserInfoDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<AdvertiserInfoDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}