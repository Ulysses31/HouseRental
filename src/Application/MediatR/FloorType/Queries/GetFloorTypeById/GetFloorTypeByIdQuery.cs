using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorType.Queries.GetFloorTypeById
{
	/// <summary>
	/// GetFloorTypeByIdQuery class
	/// </summary>
	public class GetFloorTypeByIdQuery : IRequest<SlApiResponse<FloorTypeDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetFloorTypeByIdQueryHandler class
	/// </summary>
	public class GetFloorTypeByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetFloorTypeByIdQuery, SlApiResponse<FloorTypeDto, object>>
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
		/// SlApiResponse FloorTypeDto
		/// </summary>
		private readonly SlApiResponse<FloorTypeDto, object> _response;

		/// <summary>
		/// GetFloorTypeByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse FloorTypeDto</param>
		public GetFloorTypeByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<FloorTypeDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetFloorTypeByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		public async Task<SlApiResponse<FloorTypeDto, object>> Handle(
			GetFloorTypeByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorTypeRepo.GetById(
				request.Id
			);
		}
	}
}