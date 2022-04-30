using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Queries.GetGoogleMapPlaceById
{
	/// <summary>
	/// GetGoogleMapPlaceByIdQuery class
	/// </summary>
	public class GetGoogleMapPlaceByIdQuery : IRequest<SlApiResponse<GoogleMapPlaceDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetGoogleMapPlaceByIdQueryHandler class
	/// </summary>
	public class GetGoogleMapPlaceByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetGoogleMapPlaceByIdQuery, SlApiResponse<GoogleMapPlaceDto, object>>
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
		/// SlApiResponse GoogleMapPlaceDto
		/// </summary>
		private readonly SlApiResponse<GoogleMapPlaceDto, object> _response;

		/// <summary>
		/// GetGoogleMapPlaceByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse GoogleMapPlaceDto</param>
		public GetGoogleMapPlaceByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<GoogleMapPlaceDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetGoogleMapPlaceByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> Handle(
			GetGoogleMapPlaceByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.GoogleMapPlaceRepo.GetById(
				request.Id
			);
		}
	}
}