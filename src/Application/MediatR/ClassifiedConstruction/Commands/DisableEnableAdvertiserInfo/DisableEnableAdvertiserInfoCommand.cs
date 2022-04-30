using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.DisableEnableClassifiedConstruction
{
	public class DisableEnableClassifiedConstructionCommand : IRequest<SlApiResponse<ClassifiedConstructionDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableClassifiedConstructionCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableClassifiedConstructionCommand, SlApiResponse<ClassifiedConstructionDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedConstructionDto, object> _response;

		public DisableEnableClassifiedConstructionCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedConstructionDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> Handle(
			DisableEnableClassifiedConstructionCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedConstructionRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}