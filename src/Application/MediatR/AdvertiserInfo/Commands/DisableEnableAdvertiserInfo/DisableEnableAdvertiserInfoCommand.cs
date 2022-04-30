using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.DisableEnableAdvertiserInfo
{
	public class DisableEnableAdvertiserInfoCommand : IRequest<SlApiResponse<AdvertiserInfoDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableAdvertiserInfoCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableAdvertiserInfoCommand, SlApiResponse<AdvertiserInfoDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<AdvertiserInfoDto, object> _response;

		public DisableEnableAdvertiserInfoCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<AdvertiserInfoDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<AdvertiserInfoDto, object>> Handle(
			DisableEnableAdvertiserInfoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.AdvertiserInfoRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}