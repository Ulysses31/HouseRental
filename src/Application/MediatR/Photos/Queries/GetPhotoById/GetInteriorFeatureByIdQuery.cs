using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.Photo.Queries.GetPhotoById
{
	/// <summary>
	/// GetPhotoByIdQuery class
	/// </summary>
	public class GetPhotoByIdQuery : IRequest<SlApiResponse<PhotosDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetPhotoByIdQueryHandler class
	/// </summary>
	public class GetPhotoByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetPhotoByIdQuery, SlApiResponse<PhotosDto, object>>
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
		/// SlApiResponse PhotosDto
		/// </summary>
		private readonly SlApiResponse<PhotosDto, object> _response;

		/// <summary>
		/// GetPhotoByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PhotosDto</param>
		public GetPhotoByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PhotosDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetPhotoByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		public async Task<SlApiResponse<PhotosDto, object>> Handle(
			GetPhotoByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PhotoRepo.GetById(
				request.Id
			);
		}
	}
}