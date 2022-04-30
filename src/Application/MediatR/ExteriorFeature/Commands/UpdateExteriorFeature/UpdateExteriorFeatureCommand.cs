using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.UpdateExteriorFeature
{
	public class UpdateExteriorFeatureCommand : IRequest<SlApiResponse<ExteriorFeatureDto, object>>
	{
		public int Id { get; set; }
		public ExteriorFeatureDto ExteriorFeatureDto { get; set; }
	}

	public class UpdateExteriorFeatureCommandHandler : BaseRequestHandler, IRequestHandler<UpdateExteriorFeatureCommand, SlApiResponse<ExteriorFeatureDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ExteriorFeatureDto, object> _response;

		public UpdateExteriorFeatureCommandHandler(
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
			UpdateExteriorFeatureCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ExteriorFeatureRepo.UpdateDtoById(
				request.Id,
				request.ExteriorFeatureDto,
				cancellationToken
			);
		}
	}
}