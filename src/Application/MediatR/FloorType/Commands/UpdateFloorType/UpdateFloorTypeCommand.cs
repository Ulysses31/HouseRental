using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorType.Commands.UpdateFloorType
{
	public class UpdateFloorTypeCommand : IRequest<SlApiResponse<FloorTypeDto, object>>
	{
		public int Id { get; set; }
		public FloorTypeDto FloorTypeDto { get; set; }
	}

	public class UpdateFloorTypeCommandHandler : BaseRequestHandler, IRequestHandler<UpdateFloorTypeCommand, SlApiResponse<FloorTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FloorTypeDto, object> _response;

		public UpdateFloorTypeCommandHandler(
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
			UpdateFloorTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorTypeRepo.UpdateDtoById(
				request.Id,
				request.FloorTypeDto,
				cancellationToken
			);
		}
	}
}