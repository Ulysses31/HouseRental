using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorNo.Commands.CreateFloorNo
{
	public class CreateFloorNoCommand : IRequest<SlApiResponse<FloorNoDto, object>>
	{
		public FloorNoDto FloorNoDto { get; set; }
	}

	public class CreateFloorNoCommandHandler : BaseRequestHandler, IRequestHandler<CreateFloorNoCommand, SlApiResponse<FloorNoDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FloorNoDto, object> _response;

		public CreateFloorNoCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<FloorNoDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<FloorNoDto, object>> Handle(
			CreateFloorNoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorNoRepo.AddDto(
				request.FloorNoDto,
				cancellationToken
			);
		}
	}
}