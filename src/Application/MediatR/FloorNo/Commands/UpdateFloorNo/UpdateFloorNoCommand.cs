using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorNo.Commands.UpdateFloorNo
{
	public class UpdateFloorNoCommand : IRequest<SlApiResponse<FloorNoDto, object>>
	{
		public int Id { get; set; }
		public FloorNoDto FloorNoDto { get; set; }
	}

	public class UpdateFloorNoCommandHandler : BaseRequestHandler, IRequestHandler<UpdateFloorNoCommand, SlApiResponse<FloorNoDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FloorNoDto, object> _response;

		public UpdateFloorNoCommandHandler(
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
			UpdateFloorNoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorNoRepo.UpdateDtoById(
				request.Id,
				request.FloorNoDto,
				cancellationToken
			);
		}
	}
}