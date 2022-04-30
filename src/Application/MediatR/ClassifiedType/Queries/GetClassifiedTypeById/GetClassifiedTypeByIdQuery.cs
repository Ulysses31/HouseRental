using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Queries.GetClassifiedTypeById
{
	/// <summary>
	/// GetClassifiedTypeByIdQuery class
	/// </summary>
	public class GetClassifiedTypeByIdQuery : IRequest<SlApiResponse<ClassifiedTypeDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetClassifiedTypeByIdQueryHandler class
	/// </summary>
	public class GetClassifiedTypeByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedTypeByIdQuery, SlApiResponse<ClassifiedTypeDto, object>>
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
		/// SlApiResponse ClassifiedTypeDto
		/// </summary>
		private readonly SlApiResponse<ClassifiedTypeDto, object> _response;

		/// <summary>
		/// GetClassifiedTypeByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse ClassifiedTypeDto</param>
		public GetClassifiedTypeByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedTypeDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedTypeByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> Handle(
			GetClassifiedTypeByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedTypeRepo.GetById(
				request.Id
			);
		}
	}
}