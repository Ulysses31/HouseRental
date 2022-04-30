using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Commands.DisableEnableInteriorFeature
{
	public class DisableEnableInteriorFeatureCommand : IRequest<SlApiResponse<InteriorFeatureDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableInteriorFeatureCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableInteriorFeatureCommand, SlApiResponse<InteriorFeatureDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<InteriorFeatureDto, object> _response;

		public DisableEnableInteriorFeatureCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<InteriorFeatureDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<InteriorFeatureDto, object>> Handle(
			DisableEnableInteriorFeatureCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.InteriorFeatureRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}