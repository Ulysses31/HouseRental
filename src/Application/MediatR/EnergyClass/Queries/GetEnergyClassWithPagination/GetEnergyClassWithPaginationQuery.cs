using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Queries.GetEnergyClassWithPagination
{
	/// <summary>
	/// GetEnergyClassWithPaginationQuery class
	/// </summary>
	public class GetEnergyClassWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<EnergyClassDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetEnergyClassWithPaginationQueryHandler class
	/// </summary>
	public class GetEnergyClassWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetEnergyClassWithPaginationQuery, SlApiResponse<PaginatedList<EnergyClassDto>, object>>
	{
		/// <summary>
		/// IRepoManager _repoManager
		/// </summary>
		private readonly IRepoManager _repoManager;

		/// <summary>
		/// IMapper _mapper
		/// </summary>
		private readonly IMapper _mapper;

		/// <summary>
		/// SlApiResponse PaginatedList EnergyClassDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<EnergyClassDto>, object> _response;

		/// <summary>
		/// GetEnergyClassWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList EnergyClassDto</param>
		public GetEnergyClassWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<EnergyClassDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetEnergyClassWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<EnergyClassDto>, object>>
			IRequestHandler<GetEnergyClassWithPaginationQuery, SlApiResponse<PaginatedList<EnergyClassDto>, object>>.Handle(
			GetEnergyClassWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.EnergyClassRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}