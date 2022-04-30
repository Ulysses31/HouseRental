using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.DisableEnableClassifiedCharacteristics
{
	public class DisableEnableClassifiedCharacteristicsCommand : IRequest<SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableClassifiedCharacteristicsCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableClassifiedCharacteristicsCommand, SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedCharacteristicsDto, object> _response;

		public DisableEnableClassifiedCharacteristicsCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> Handle(
			DisableEnableClassifiedCharacteristicsCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedCharacteristicsRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}