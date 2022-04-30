using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Queries.GetClassifiedPurposeWithPagination
{
	/// <summary>
	/// GetClassifiedPurposeWithPaginationQuery class
	/// </summary>
	public class GetClassifiedPurposeWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetClassifiedPurposeWithPaginationQueryHandler class
	/// </summary>
	public class GetClassifiedPurposeWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedPurposeWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>>
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
		/// SlApiResponse PaginatedList ClassifiedPurposeDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object> _response;

		/// <summary>
		/// GetClassifiedPurposeWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList ClassifiedPurposeDto</param>
		public GetClassifiedPurposeWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedPurposeWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>>
			IRequestHandler<GetClassifiedPurposeWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>>.Handle(
			GetClassifiedPurposeWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedPurposeRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}