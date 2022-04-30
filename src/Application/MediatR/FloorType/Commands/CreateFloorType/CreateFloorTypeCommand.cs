using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorType.Commands.CreateFloorType
{
	public class CreateFloorTypeCommand : IRequest<SlApiResponse<FloorTypeDto, object>>
	{
		public FloorTypeDto FloorTypeDto { get; set; }
	}

	public class CreateFloorTypeCommandHandler : BaseRequestHandler, IRequestHandler<CreateFloorTypeCommand, SlApiResponse<FloorTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FloorTypeDto, object> _response;

		public CreateFloorTypeCommandHandler(
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
			CreateFloorTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorTypeRepo.AddDto(
				request.FloorTypeDto,
				cancellationToken
			);
		}
	}
}