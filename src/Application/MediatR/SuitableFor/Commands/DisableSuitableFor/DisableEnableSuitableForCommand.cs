using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Commands.DisableEnableSuitableFor
{
	public class DisableEnableSuitableForCommand : IRequest<SlApiResponse<SuitableForDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableSuitableForCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableSuitableForCommand, SlApiResponse<SuitableForDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<SuitableForDto, object> _response;

		public DisableEnableSuitableForCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<SuitableForDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<SuitableForDto, object>> Handle(
			DisableEnableSuitableForCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.SuitableForRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}