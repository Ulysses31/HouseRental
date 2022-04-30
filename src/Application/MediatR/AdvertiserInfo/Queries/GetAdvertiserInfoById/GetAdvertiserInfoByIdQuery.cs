using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Queries.GetAdvertiserInfoById
{
	/// <summary>
	/// GetAdvertiserInfoByIdQuery class
	/// </summary>
	public class GetAdvertiserInfoByIdQuery : IRequest<SlApiResponse<AdvertiserInfoDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetAdvertiserInfoByIdQueryHandler class
	/// </summary>
	public class GetAdvertiserInfoByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetAdvertiserInfoByIdQuery, SlApiResponse<AdvertiserInfoDto, object>>
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
		/// SlApiResponse AdvertiserInfoDto
		/// </summary>
		private readonly SlApiResponse<AdvertiserInfoDto, object> _response;

		/// <summary>
		/// GetAdvertiserInfoByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse AdvertiserInfoDto</param>
		public GetAdvertiserInfoByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<AdvertiserInfoDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetAdvertiserInfoByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> Handle(
			GetAdvertiserInfoByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.AdvertiserInfoRepo.GetById(
				request.Id
			);
		}
	}
}