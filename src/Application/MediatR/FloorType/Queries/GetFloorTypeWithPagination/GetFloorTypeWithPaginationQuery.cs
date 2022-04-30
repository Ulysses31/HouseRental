using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorType.Queries.GetFloorTypeWithPagination
{
	/// <summary>
	/// GetFloorTypeWithPaginationQuery class
	/// </summary>
	public class GetFloorTypeWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<FloorTypeDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetFloorTypeWithPaginationQueryHandler class
	/// </summary>
	public class GetFloorTypeWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetFloorTypeWithPaginationQuery, SlApiResponse<PaginatedList<FloorTypeDto>, object>>
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
		/// SlApiResponse PaginatedList FloorTypeDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<FloorTypeDto>, object> _response;

		/// <summary>
		/// GetFloorTypeWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList FloorTypeDto</param>
		public GetFloorTypeWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<FloorTypeDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetFloorTypeWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<FloorTypeDto>, object>>
			IRequestHandler<GetFloorTypeWithPaginationQuery, SlApiResponse<PaginatedList<FloorTypeDto>, object>>.Handle(
			GetFloorTypeWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorTypeRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}