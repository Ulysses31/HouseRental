using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.DeleteAdvertiserInfo
{
	public class DeleteAdvertiserInfoCommand : IRequest<SlApiResponse<AdvertiserInfoDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeleteAdvertiserInfoCommandHandler : BaseRequestHandler, IRequestHandler<DeleteAdvertiserInfoCommand, SlApiResponse<AdvertiserInfoDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<AdvertiserInfoDto, object> _response;

		public DeleteAdvertiserInfoCommandHandler(
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
			DeleteAdvertiserInfoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.AdvertiserInfoRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}