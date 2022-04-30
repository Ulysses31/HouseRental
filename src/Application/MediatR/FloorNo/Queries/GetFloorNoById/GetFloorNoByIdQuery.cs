using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorNo.Queries.GetFloorNoById
{
	/// <summary>
	/// GetFloorNoByIdQuery class
	/// </summary>
	public class GetFloorNoByIdQuery : IRequest<SlApiResponse<FloorNoDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetFloorNoByIdQueryHandler class
	/// </summary>
	public class GetFloorNoByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetFloorNoByIdQuery, SlApiResponse<FloorNoDto, object>>
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
		/// SlApiResponse FloorNoDto
		/// </summary>
		private readonly SlApiResponse<FloorNoDto, object> _response;

		/// <summary>
		/// GetFloorNoByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse FloorNoDto</param>
		public GetFloorNoByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<FloorNoDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetFloorNoByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		public async Task<SlApiResponse<FloorNoDto, object>> Handle(
			GetFloorNoByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorNoRepo.GetById(
				request.Id
			);
		}
	}
}