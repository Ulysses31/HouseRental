using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Queries.GetSuitableForById
{
	/// <summary>
	/// GetSuitableForByIdQuery class
	/// </summary>
	public class GetSuitableForByIdQuery : IRequest<SlApiResponse<SuitableForDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetSuitableForByIdQueryHandler class
	/// </summary>
	public class GetSuitableForByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetSuitableForByIdQuery, SlApiResponse<SuitableForDto, object>>
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
		/// SlApiResponse SuitableForDto
		/// </summary>
		private readonly SlApiResponse<SuitableForDto, object> _response;

		/// <summary>
		/// GetSuitableForByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse SuitableForDto</param>
		public GetSuitableForByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<SuitableForDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetSuitableForByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		public async Task<SlApiResponse<SuitableForDto, object>> Handle(
			GetSuitableForByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.SuitableForRepo.GetById(
				request.Id
			);
		}
	}
}