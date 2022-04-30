using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorNo.Queries.GetFloorNoWithPagination
{
	/// <summary>
	/// GetFloorNoWithPaginationQuery class
	/// </summary>
	public class GetFloorNoWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<FloorNoDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetFloorNoWithPaginationQueryHandler class
	/// </summary>
	public class GetFloorNoWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetFloorNoWithPaginationQuery, SlApiResponse<PaginatedList<FloorNoDto>, object>>
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
		/// SlApiResponse PaginatedList FloorNoDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<FloorNoDto>, object> _response;

		/// <summary>
		/// GetFloorNoWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList FloorNoDto</param>
		public GetFloorNoWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<FloorNoDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetFloorNoWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<FloorNoDto>, object>>
			IRequestHandler<GetFloorNoWithPaginationQuery, SlApiResponse<PaginatedList<FloorNoDto>, object>>.Handle(
			GetFloorNoWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorNoRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}