using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.CreateExteriorFeature
{
	public class CreateExteriorFeatureCommand : IRequest<SlApiResponse<ExteriorFeatureDto, object>>
	{
		public ExteriorFeatureDto ExteriorFeatureDto { get; set; }
	}

	public class CreateExteriorFeatureCommandHandler : BaseRequestHandler, IRequestHandler<CreateExteriorFeatureCommand, SlApiResponse<ExteriorFeatureDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ExteriorFeatureDto, object> _response;

		public CreateExteriorFeatureCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ExteriorFeatureDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<ExteriorFeatureDto, object>> Handle(
			CreateExteriorFeatureCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ExteriorFeatureRepo.AddDto(
				request.ExteriorFeatureDto,
				cancellationToken
			);
		}
	}
}