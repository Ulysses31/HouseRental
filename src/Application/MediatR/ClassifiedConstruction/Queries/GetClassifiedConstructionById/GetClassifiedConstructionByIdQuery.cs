using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Queries.GetClassifiedConstructionById
{
	/// <summary>
	/// GetClassifiedConstructionByIdQuery class
	/// </summary>
	public class GetClassifiedConstructionByIdQuery : IRequest<SlApiResponse<ClassifiedConstructionDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetClassifiedConstructionByIdQueryHandler class
	/// </summary>
	public class GetClassifiedConstructionByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedConstructionByIdQuery, SlApiResponse<ClassifiedConstructionDto, object>>
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
		/// SlApiResponse ClassifiedConstructionDto
		/// </summary>
		private readonly SlApiResponse<ClassifiedConstructionDto, object> _response;

		/// <summary>
		/// GetClassifiedConstructionByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse ClassifiedConstructionDto</param>
		public GetClassifiedConstructionByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedConstructionDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedConstructionByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> Handle(
			GetClassifiedConstructionByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedConstructionRepo.GetById(
				request.Id
			);
		}
	}
}