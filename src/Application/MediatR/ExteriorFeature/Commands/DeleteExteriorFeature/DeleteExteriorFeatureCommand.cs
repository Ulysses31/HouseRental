using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.DeleteExteriorFeature
{
	public class DeleteExteriorFeatureCommand : IRequest<SlApiResponse<ExteriorFeatureDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeleteExteriorFeatureCommandHandler : BaseRequestHandler, IRequestHandler<DeleteExteriorFeatureCommand, SlApiResponse<ExteriorFeatureDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ExteriorFeatureDto, object> _response;

		public DeleteExteriorFeatureCommandHandler(
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
			DeleteExteriorFeatureCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ExteriorFeatureRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}