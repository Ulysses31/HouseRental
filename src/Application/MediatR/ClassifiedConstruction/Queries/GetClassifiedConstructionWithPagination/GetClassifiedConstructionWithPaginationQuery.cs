using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Queries.GetClassifiedConstructionWithPagination
{
	/// <summary>
	/// GetClassifiedConstructionsWithPaginationQuery class
	/// </summary>
	public class GetClassifiedConstructionsWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetClassifiedConstructionsWithPaginationQueryHandler class
	/// </summary>
	public class GetClassifiedConstructionsWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedConstructionsWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>>
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
		/// SlApiResponse PaginatedList ClassifiedConstructionDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object> _response;

		/// <summary>
		/// GetClassifiedConstructionsWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList ClassifiedConstructionDto</param>
		public GetClassifiedConstructionsWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedConstructionsWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>>
			IRequestHandler<GetClassifiedConstructionsWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>>.Handle(
			GetClassifiedConstructionsWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedConstructionRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}