using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Queries.GetClassifiedPurposeById
{
	/// <summary>
	/// GetClassifiedPurposeByIdQuery class
	/// </summary>
	public class GetClassifiedPurposeByIdQuery : IRequest<SlApiResponse<ClassifiedPurposeDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetClassifiedPurposeByIdQueryHandler class
	/// </summary>
	public class GetClassifiedPurposeByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedPurposeByIdQuery, SlApiResponse<ClassifiedPurposeDto, object>>
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
		/// SlApiResponse ClassifiedPurposeDto
		/// </summary>
		private readonly SlApiResponse<ClassifiedPurposeDto, object> _response;

		/// <summary>
		/// GetClassifiedPurposeByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse ClassifiedPurposeDto</param>
		public GetClassifiedPurposeByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedPurposeDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedPurposeByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> Handle(
			GetClassifiedPurposeByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedPurposeRepo.GetById(
				request.Id
			);
		}
	}
}