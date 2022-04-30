using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Queries.GetHeatingSystemWithPagination
{
	/// <summary>
	/// GetHeatingSystemWithPaginationQuery class
	/// </summary>
	public class GetHeatingSystemWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<HeatingSystemDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetHeatingSystemWithPaginationQueryHandler class
	/// </summary>
	public class GetHeatingSystemWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetHeatingSystemWithPaginationQuery, SlApiResponse<PaginatedList<HeatingSystemDto>, object>>
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
		/// SlApiResponse PaginatedList HeatingSystemDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<HeatingSystemDto>, object> _response;

		/// <summary>
		/// GetHeatingSystemWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList HeatingSystemDto</param>
		public GetHeatingSystemWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<HeatingSystemDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetHeatingSystemWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<HeatingSystemDto>, object>>
			IRequestHandler<GetHeatingSystemWithPaginationQuery, SlApiResponse<PaginatedList<HeatingSystemDto>, object>>.Handle(
			GetHeatingSystemWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingSystemRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}