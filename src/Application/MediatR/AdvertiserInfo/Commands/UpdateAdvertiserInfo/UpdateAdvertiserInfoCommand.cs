using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.UpdateAdvertiserInfo
{
	public class UpdateAdvertiserInfoCommand : IRequest<SlApiResponse<AdvertiserInfoDto, object>>
	{
		public int Id { get; set; }
		public AdvertiserInfoDto AdvertiserInfoDto { get; set; }
	}

	public class UpdateAdvertiserInfoCommandHandler : BaseRequestHandler, IRequestHandler<UpdateAdvertiserInfoCommand, SlApiResponse<AdvertiserInfoDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<AdvertiserInfoDto, object> _response;

		public UpdateAdvertiserInfoCommandHandler(
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
			UpdateAdvertiserInfoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.AdvertiserInfoRepo.UpdateDtoById(
				request.Id,
				request.AdvertiserInfoDto,
				cancellationToken
			);
		}
	}
}