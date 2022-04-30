using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.PowerType.Queries.GetPowerTypeById
{
	/// <summary>
	/// GetPowerTypeByIdQuery class
	/// </summary>
	public class GetPowerTypeByIdQuery : IRequest<SlApiResponse<PowerTypeDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetPowerTypeByIdQueryHandler class
	/// </summary>
	public class GetPowerTypeByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetPowerTypeByIdQuery, SlApiResponse<PowerTypeDto, object>>
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
		/// SlApiResponse PowerTypeDto
		/// </summary>
		private readonly SlApiResponse<PowerTypeDto, object> _response;

		/// <summary>
		/// GetPowerTypeByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse PowerTypeDto</param>
		public GetPowerTypeByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PowerTypeDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetPowerTypeByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		public async Task<SlApiResponse<PowerTypeDto, object>> Handle(
			GetPowerTypeByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PowerTypeRepo.GetById(
				request.Id
			);
		}
	}
}