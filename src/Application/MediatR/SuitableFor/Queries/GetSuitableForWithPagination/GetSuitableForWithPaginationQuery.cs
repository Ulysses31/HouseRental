﻿using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Queries.GetSuitableForWithPagination
{
	/// <summary>
	/// GetSuitableForWithPaginationQuery class
	/// </summary>
	public class GetSuitableForWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<SuitableForDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetSuitableForWithPaginationQueryHandler class
	/// </summary>
	public class GetSuitableForWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetSuitableForWithPaginationQuery, SlApiResponse<PaginatedList<SuitableForDto>, object>>
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
		/// SlApiResponse PaginatedList SuitableForDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<SuitableForDto>, object> _response;

		/// <summary>
		/// GetSuitableForWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList SuitableForDto</param>
		public GetSuitableForWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<SuitableForDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetSuitableForWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<SuitableForDto>, object>>
			IRequestHandler<GetSuitableForWithPaginationQuery, SlApiResponse<PaginatedList<SuitableForDto>, object>>.Handle(
			GetSuitableForWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.SuitableForRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}