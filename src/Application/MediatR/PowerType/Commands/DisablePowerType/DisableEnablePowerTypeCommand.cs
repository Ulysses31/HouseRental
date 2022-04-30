using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.DisableEnablePowerType
{
	public class DisableEnablePowerTypeCommand : IRequest<SlApiResponse<PowerTypeDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnablePowerTypeCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnablePowerTypeCommand, SlApiResponse<PowerTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PowerTypeDto, object> _response;

		public DisableEnablePowerTypeCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PowerTypeDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<PowerTypeDto, object>> Handle(
			DisableEnablePowerTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PowerTypeRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}