using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Queries.GetHeatingSystemById
{
	/// <summary>
	/// GetHeatingSystemByIdQuery class
	/// </summary>
	public class GetHeatingSystemByIdQuery : IRequest<SlApiResponse<HeatingSystemDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetHeatingSystemByIdQueryHandler class
	/// </summary>
	public class GetHeatingSystemByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetHeatingSystemByIdQuery, SlApiResponse<HeatingSystemDto, object>>
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
		/// SlApiResponse HeatingSystemDto
		/// </summary>
		private readonly SlApiResponse<HeatingSystemDto, object> _response;

		/// <summary>
		/// GetHeatingSystemByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse HeatingSystemDto</param>
		public GetHeatingSystemByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<HeatingSystemDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetHeatingSystemByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		public async Task<SlApiResponse<HeatingSystemDto, object>> Handle(
			GetHeatingSystemByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingSystemRepo.GetById(
				request.Id
			);
		}
	}
}