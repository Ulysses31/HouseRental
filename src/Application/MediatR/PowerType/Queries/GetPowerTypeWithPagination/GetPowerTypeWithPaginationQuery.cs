using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.PowerType.Queries.GetPowerTypeWithPagination
{
	/// <summary>
	/// GetPowerTypeWithPaginationQuery class
	/// </summary>
	public class GetPowerTypeWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<PowerTypeDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetPowerTypeWithPaginationQueryHandler class
	/// </summary>
	public class GetPowerTypeWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetPowerTypeWithPaginationQuery, SlApiResponse<PaginatedList<PowerTypeDto>, object>>
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
		/// SlApiResponse PaginatedList PowerTypeDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<PowerTypeDto>, object> _response;

		/// <summary>
		/// GetPowerTypeWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList PowerTypeDto</param>
		public GetPowerTypeWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<PowerTypeDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetPowerTypeWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<PowerTypeDto>, object>>
			IRequestHandler<GetPowerTypeWithPaginationQuery, SlApiResponse<PaginatedList<PowerTypeDto>, object>>.Handle(
			GetPowerTypeWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PowerTypeRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}