using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Queries.GetClassifiedCharacteristicsWithPagination
{
	/// <summary>
	/// GetClassifiedCharacteristicssWithPaginationQuery class
	/// </summary>
	public class GetClassifiedCharacteristicsWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetClassifiedCharacteristicssWithPaginationQueryHandler class
	/// </summary>
	public class GetClassifiedCharacteristicsWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedCharacteristicsWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>>
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
		/// SlApiResponse PaginatedList ClassifiedCharacteristicsDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object> _response;

		/// <summary>
		/// GetClassifiedCharacteristicssWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList ClassifiedCharacteristicsDto</param>
		public GetClassifiedCharacteristicsWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedCharacteristicssWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>>
			IRequestHandler<GetClassifiedCharacteristicsWithPaginationQuery, SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>>.Handle(
			GetClassifiedCharacteristicsWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedCharacteristicsRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}