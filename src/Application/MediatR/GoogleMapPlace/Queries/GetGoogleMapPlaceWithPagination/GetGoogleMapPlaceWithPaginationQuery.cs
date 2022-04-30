using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Queries.GetGoogleMapPlaceWithPagination
{
	/// <summary>
	/// GetGoogleMapPlaceWithPaginationQuery class
	/// </summary>
	public class GetGoogleMapPlaceWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetGoogleMapPlaceWithPaginationQueryHandler class
	/// </summary>
	public class GetGoogleMapPlaceWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetGoogleMapPlaceWithPaginationQuery, SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>>
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
		/// SlApiResponse PaginatedList GoogleMapPlaceDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object> _response;

		/// <summary>
		/// GetGoogleMapPlaceWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList GoogleMapPlaceDto</param>
		public GetGoogleMapPlaceWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetGoogleMapPlaceWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>>
			IRequestHandler<GetGoogleMapPlaceWithPaginationQuery, SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>>.Handle(
			GetGoogleMapPlaceWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.GoogleMapPlaceRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}