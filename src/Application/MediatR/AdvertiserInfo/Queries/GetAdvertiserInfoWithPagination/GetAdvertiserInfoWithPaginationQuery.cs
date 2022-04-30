using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Queries.GetAdvertiserInfoWithPagination
{
	/// <summary>
	/// GetAdvertiserInfosWithPaginationQuery class
	/// </summary>
	public class GetAdvertiserInfosWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetAdvertiserInfosWithPaginationQueryHandler class
	/// </summary>
	public class GetAdvertiserInfosWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetAdvertiserInfosWithPaginationQuery, SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>>
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
		/// SlApiResponse PaginatedList AdvertiserInfoDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<AdvertiserInfoDto>, object> _response;

		/// <summary>
		/// GetAdvertiserInfosWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList AdvertiserInfoDto</param>
		public GetAdvertiserInfosWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<AdvertiserInfoDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetAdvertiserInfosWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>>
			IRequestHandler<GetAdvertiserInfosWithPaginationQuery, SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>>.Handle(
			GetAdvertiserInfosWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.AdvertiserInfoRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}