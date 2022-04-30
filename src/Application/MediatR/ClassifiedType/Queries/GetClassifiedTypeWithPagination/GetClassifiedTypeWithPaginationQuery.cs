using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Queries.GetClassifiedTypeWithPagination
{
	/// <summary>
	/// GetClassifiedTypeWithPaginationQuery class
	/// </summary>
	public class GetClassifiedTypeWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetClassifiedTypeWithPaginationQueryHandler class
	/// </summary>
	public class GetClassifiedTypeWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedTypeWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>>
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
		/// SlApiResponse PaginatedList ClassifiedTypeDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<ClassifiedTypeDto>, object> _response;

		/// <summary>
		/// GetClassifiedTypeWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList ClassifiedTypeDto</param>
		public GetClassifiedTypeWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<ClassifiedTypeDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedTypeWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>>
			IRequestHandler<GetClassifiedTypeWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>>.Handle(
			GetClassifiedTypeWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedTypeRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}