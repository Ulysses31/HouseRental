using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingType.Queries.GetHeatingTypeById
{
	/// <summary>
	/// GetHeatingTypeByIdQuery class
	/// </summary>
	public class GetHeatingTypeByIdQuery : IRequest<SlApiResponse<HeatingTypeDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetHeatingTypeByIdQueryHandler class
	/// </summary>
	public class GetHeatingTypeByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetHeatingTypeByIdQuery, SlApiResponse<HeatingTypeDto, object>>
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
		/// SlApiResponse HeatingTypeDto
		/// </summary>
		private readonly SlApiResponse<HeatingTypeDto, object> _response;

		/// <summary>
		/// GetHeatingTypeByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse HeatingTypeDto</param>
		public GetHeatingTypeByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<HeatingTypeDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetHeatingTypeByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		public async Task<SlApiResponse<HeatingTypeDto, object>> Handle(
			GetHeatingTypeByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingTypeRepo.GetById(
				request.Id
			);
		}
	}
}