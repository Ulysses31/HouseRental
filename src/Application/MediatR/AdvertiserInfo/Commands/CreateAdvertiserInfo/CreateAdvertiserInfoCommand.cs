using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.CreateAdvertiserInfo
{
	public class CreateAdvertiserInfoCommand : IRequest<SlApiResponse<AdvertiserInfoDto, object>>
	{
		public AdvertiserInfoDto AdvertiserInfoDto { get; set; }
	}

	public class CreateAdvertiserInfoCommandHandler : BaseRequestHandler, IRequestHandler<CreateAdvertiserInfoCommand, SlApiResponse<AdvertiserInfoDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<AdvertiserInfoDto, object> _response;

		public CreateAdvertiserInfoCommandHandler(
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
			CreateAdvertiserInfoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.AdvertiserInfoRepo.AddDto(
				request.AdvertiserInfoDto,
				cancellationToken
			);
		}
	}
}