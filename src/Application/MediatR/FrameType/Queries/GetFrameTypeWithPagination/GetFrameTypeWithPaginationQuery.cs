using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FrameType.Queries.GetFrameTypeWithPagination
{
	/// <summary>
	/// GetFrameTypeWithPaginationQuery class
	/// </summary>
	public class GetFrameTypeWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<FrameTypeDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetFrameTypeWithPaginationQueryHandler class
	/// </summary>
	public class GetFrameTypeWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetFrameTypeWithPaginationQuery, SlApiResponse<PaginatedList<FrameTypeDto>, object>>
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
		/// SlApiResponse PaginatedList FrameTypeDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<FrameTypeDto>, object> _response;

		/// <summary>
		/// GetFrameTypeWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList FrameTypeDto</param>
		public GetFrameTypeWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<FrameTypeDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetFrameTypeWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<FrameTypeDto>, object>>
			IRequestHandler<GetFrameTypeWithPaginationQuery, SlApiResponse<PaginatedList<FrameTypeDto>, object>>.Handle(
			GetFrameTypeWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FrameTypeRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}