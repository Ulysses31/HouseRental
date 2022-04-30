using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FrameType.Commands.DisableEnableFrameType
{
	public class DisableEnableFrameTypeCommand : IRequest<SlApiResponse<FrameTypeDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableFrameTypeCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableFrameTypeCommand, SlApiResponse<FrameTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FrameTypeDto, object> _response;

		public DisableEnableFrameTypeCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<FrameTypeDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<FrameTypeDto, object>> Handle(
			DisableEnableFrameTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FrameTypeRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}