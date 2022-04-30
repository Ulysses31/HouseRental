using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FrameType.Queries.GetFrameTypeById
{
	/// <summary>
	/// GetFrameTypeByIdQuery class
	/// </summary>
	public class GetFrameTypeByIdQuery : IRequest<SlApiResponse<FrameTypeDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetFrameTypeByIdQueryHandler class
	/// </summary>
	public class GetFrameTypeByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetFrameTypeByIdQuery, SlApiResponse<FrameTypeDto, object>>
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
		/// SlApiResponse FrameTypeDto
		/// </summary>
		private readonly SlApiResponse<FrameTypeDto, object> _response;

		/// <summary>
		/// GetFrameTypeByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse FrameTypeDto</param>
		public GetFrameTypeByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<FrameTypeDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetFrameTypeByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		public async Task<SlApiResponse<FrameTypeDto, object>> Handle(
			GetFrameTypeByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FrameTypeRepo.GetById(
				request.Id
			);
		}
	}
}