using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Commands.DisableEnableHeatingSystem
{
	public class DisableEnableHeatingSystemCommand : IRequest<SlApiResponse<HeatingSystemDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableHeatingSystemCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableHeatingSystemCommand, SlApiResponse<HeatingSystemDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<HeatingSystemDto, object> _response;

		public DisableEnableHeatingSystemCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<HeatingSystemDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<HeatingSystemDto, object>> Handle(
			DisableEnableHeatingSystemCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingSystemRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}