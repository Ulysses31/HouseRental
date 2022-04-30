using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Repository.Interfaces.EnergyClass
{
	/// <summary>
	/// IEnergyClassRepo interface
	/// </summary>
	public interface IEnergyClassRepo : IBaseRepo<EnergyClassDto, EnergyClassDto>
	{
		public Task<SlApiResponse<PaginatedList<EnergyClassDto>, object>> GetAllWithPagination(
			[FromQuery] SlApiPaginationQuery query
	);

		public Task<SlApiResponse<EnergyClassDto, object>> GetById(
			int id
		);

		public Task<SlApiResponse<EnergyClassDto, object>> UpdateDtoById(
			int id,
			EnergyClassDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<EnergyClassDto, object>> AddDto(
			EnergyClassDto dto,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<EnergyClassDto, object>> DeleteDtoById(
			int id,
			CancellationToken cancellationToken
		);

		public Task<SlApiResponse<EnergyClassDto, object>> DisableEnableDtoById(
			int id,
			CancellationToken cancellationToken
		);
	}
}