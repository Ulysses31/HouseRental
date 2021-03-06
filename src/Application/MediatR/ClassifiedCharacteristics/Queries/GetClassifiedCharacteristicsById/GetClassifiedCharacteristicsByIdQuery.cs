using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Queries.GetClassifiedCharacteristicsById
{
	/// <summary>
	/// GetClassifiedCharacteristicsByIdQuery class
	/// </summary>
	public class GetClassifiedCharacteristicsByIdQuery : IRequest<SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		/// <summary>
		/// int Id
		/// </summary>
		public int Id;
	}

	/// <summary>
	/// GetClassifiedCharacteristicsByIdQueryHandler class
	/// </summary>
	public class GetClassifiedCharacteristicsByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetClassifiedCharacteristicsByIdQuery, SlApiResponse<ClassifiedCharacteristicsDto, object>>
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
		/// SlApiResponse ClassifiedCharacteristicsDto
		/// </summary>
		private readonly SlApiResponse<ClassifiedCharacteristicsDto, object> _response;

		/// <summary>
		/// GetClassifiedCharacteristicsByIdQueryHandler constructor
		/// </summary>
		/// <param name="repoManager">IRepoManager</param>
		/// <param name="mapper">IMapper</param>
		/// <param name="response">SlApiResponse ClassifiedCharacteristicsDto</param>
		public GetClassifiedCharacteristicsByIdQueryHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response
		) : base(repoManager, mapper)
		{
			_repoManager = repoManager;
			_mapper = mapper;
			_response = response;
		}

		/// <summary>
		/// Handle
		/// </summary>
		/// <param name="request">GetClassifiedCharacteristicsByIdQuery</param>
		/// <param name="cancellationToken">CancellationToken</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> Handle(
			GetClassifiedCharacteristicsByIdQuery request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedCharacteristicsRepo.GetById(
				request.Id
			);
		}
	}
}