using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FrameType.Commands.UpdateFrameType
{
	public class UpdateFrameTypeCommand : IRequest<SlApiResponse<FrameTypeDto, object>>
	{
		public int Id { get; set; }
		public FrameTypeDto FrameTypeDto { get; set; }
	}

	public class UpdateFrameTypeCommandHandler : BaseRequestHandler, IRequestHandler<UpdateFrameTypeCommand, SlApiResponse<FrameTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FrameTypeDto, object> _response;

		public UpdateFrameTypeCommandHandler(
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
			UpdateFrameTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FrameTypeRepo.UpdateDtoById(
				request.Id,
				request.FrameTypeDto,
				cancellationToken
			);
		}
	}
}