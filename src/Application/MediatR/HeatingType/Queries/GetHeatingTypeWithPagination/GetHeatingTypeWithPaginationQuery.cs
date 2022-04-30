using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingType.Queries.GetHeatingTypeWithPagination
{
	/// <summary>
	/// GetHeatingTypeWithPaginationQuery class
	/// </summary>
	public class GetHeatingTypeWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<HeatingTypeDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetHeatingTypeWithPaginationQueryHandler class
	/// </summary>
	public class GetHeatingTypeWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetHeatingTypeWithPaginationQuery, SlApiResponse<PaginatedList<HeatingTypeDto>, object>>
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
		/// SlApiResponse PaginatedList HeatingTypeDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<HeatingTypeDto>, object> _response;

		/// <summary>
		/// GetHeatingTypeWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList HeatingTypeDto</param>
		public GetHeatingTypeWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<HeatingTypeDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetHeatingTypeWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<HeatingTypeDto>, object>>
			IRequestHandler<GetHeatingTypeWithPaginationQuery, SlApiResponse<PaginatedList<HeatingTypeDto>, object>>.Handle(
			GetHeatingTypeWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingTypeRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}