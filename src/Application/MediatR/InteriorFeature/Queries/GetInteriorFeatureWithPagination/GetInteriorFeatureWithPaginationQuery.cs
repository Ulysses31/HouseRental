using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Queries.GetInteriorFeatureWithPagination
{
	/// <summary>
	/// GetInteriorFeatureWithPaginationQuery class
	/// </summary>
	public class GetInteriorFeatureWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<InteriorFeatureDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetInteriorFeatureWithPaginationQueryHandler class
	/// </summary>
	public class GetInteriorFeatureWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetInteriorFeatureWithPaginationQuery, SlApiResponse<PaginatedList<InteriorFeatureDto>, object>>
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
		/// SlApiResponse PaginatedList InteriorFeatureDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<InteriorFeatureDto>, object> _response;

		/// <summary>
		/// GetInteriorFeatureWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList InteriorFeatureDto</param>
		public GetInteriorFeatureWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<InteriorFeatureDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetInteriorFeatureWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<InteriorFeatureDto>, object>>
			IRequestHandler<GetInteriorFeatureWithPaginationQuery, SlApiResponse<PaginatedList<InteriorFeatureDto>, object>>.Handle(
			GetInteriorFeatureWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.InteriorFeatureRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}