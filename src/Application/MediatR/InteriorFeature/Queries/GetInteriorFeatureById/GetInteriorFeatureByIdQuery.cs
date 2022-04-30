using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Queries.GetInteriorFeatureById
{
	/// <summary>
	/// GetInteriorFeatureByIdQuery class
	/// </summary>
	public class GetInteriorFeatureByIdQuery : IRequest<SlApiResponse<InteriorFeatureDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetInteriorFeatureByIdQueryHandler class
	/// </summary>
	public class GetInteriorFeatureByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetInteriorFeatureByIdQuery, SlApiResponse<InteriorFeatureDto, object>>
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
		/// SlApiResponse InteriorFeatureDto
		/// </summary>
		private readonly SlApiResponse<InteriorFeatureDto, object> _response;

		/// <summary>
		/// GetInteriorFeatureByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse InteriorFeatureDto</param>
		public GetInteriorFeatureByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<InteriorFeatureDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetInteriorFeatureByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		public async Task<SlApiResponse<InteriorFeatureDto, object>> Handle(
			GetInteriorFeatureByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.InteriorFeatureRepo.GetById(
				request.Id
			);
		}
	}
}