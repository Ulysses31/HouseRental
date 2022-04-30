using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Queries.GetExteriorFeatureWithPagination
{
	/// <summary>
	/// GetExteriorFeatureWithPaginationQuery class
	/// </summary>
	public class GetExteriorFeatureWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetExteriorFeatureWithPaginationQueryHandler class
	/// </summary>
	public class GetExteriorFeatureWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetExteriorFeatureWithPaginationQuery, SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>>
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
		/// SlApiResponse PaginatedList ExteriorFeatureDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<ExteriorFeatureDto>, object> _response;

		/// <summary>
		/// GetExteriorFeatureWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList ExteriorFeatureDto</param>
		public GetExteriorFeatureWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<ExteriorFeatureDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetExteriorFeatureWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>>
			IRequestHandler<GetExteriorFeatureWithPaginationQuery, SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>>.Handle(
			GetExteriorFeatureWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ExteriorFeatureRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}