using AutoMapper;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.Photo.Queries.GetPhotoWithPagination
{
	/// <summary>
	/// GetPhotoWithPaginationQuery class
	/// </summary>
	public class GetPhotoWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<PhotosDto>, object>>
	{
		/// <summary>
		/// SlApiPaginationQuery query
		/// </summary>
		public SlApiPaginationQuery query;
	}

	/// <summary>
	/// GetPhotoWithPaginationQueryHandler class
	/// </summary>
	public class GetPhotoWithPaginationQueryHandler : BaseRequestHandler, IRequestHandler<GetPhotoWithPaginationQuery, SlApiResponse<PaginatedList<PhotosDto>, object>>
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
		/// SlApiResponse PaginatedList PhotosDto object _response
		/// </summary>
		private readonly SlApiResponse<PaginatedList<PhotosDto>, object> _response;

		/// <summary>
		/// GetPhotoWithPaginationQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PaginatedList PhotosDto</param>
		public GetPhotoWithPaginationQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PaginatedList<PhotosDto>, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetPhotoWithPaginationQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns></returns>
		async Task<SlApiResponse<PaginatedList<PhotosDto>, object>>
			IRequestHandler<GetPhotoWithPaginationQuery, SlApiResponse<PaginatedList<PhotosDto>, object>>.Handle(
			GetPhotoWithPaginationQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PhotoRepo.GetAllWithPagination(
				request.query
			);
		}
	}
}