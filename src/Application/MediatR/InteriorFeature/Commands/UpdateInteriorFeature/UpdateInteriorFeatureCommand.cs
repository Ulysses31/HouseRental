using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Commands.UpdateInteriorFeature
{
	public class UpdateInteriorFeatureCommand : IRequest<SlApiResponse<InteriorFeatureDto, object>>
	{
		public int Id { get; set; }
		public InteriorFeatureDto InteriorFeatureDto { get; set; }
	}

	public class UpdateInteriorFeatureCommandHandler : BaseRequestHandler, IRequestHandler<UpdateInteriorFeatureCommand, SlApiResponse<InteriorFeatureDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<InteriorFeatureDto, object> _response;

		public UpdateInteriorFeatureCommandHandler(
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
			UpdateInteriorFeatureCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.InteriorFeatureRepo.UpdateDtoById(
				request.Id,
				request.InteriorFeatureDto,
				cancellationToken
			);
		}
	}
}