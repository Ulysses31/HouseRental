using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorType.Commands.DisableEnableFloorType
{
	public class DisableEnableFloorTypeCommand : IRequest<SlApiResponse<FloorTypeDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableFloorTypeCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableFloorTypeCommand, SlApiResponse<FloorTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FloorTypeDto, object> _response;

		public DisableEnableFloorTypeCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<FloorTypeDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<FloorTypeDto, object>> Handle(
			DisableEnableFloorTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorTypeRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}