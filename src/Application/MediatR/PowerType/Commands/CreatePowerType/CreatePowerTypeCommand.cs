using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.CreatePowerType
{
	public class CreatePowerTypeCommand : IRequest<SlApiResponse<PowerTypeDto, object>>
	{
		public PowerTypeDto PowerTypeDto { get; set; }
	}

	public class CreatePowerTypeCommandHandler : BaseRequestHandler, IRequestHandler<CreatePowerTypeCommand, SlApiResponse<PowerTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PowerTypeDto, object> _response;

		public CreatePowerTypeCommandHandler(
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
			CreatePowerTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PowerTypeRepo.AddDto(
				request.PowerTypeDto,
				cancellationToken
			);
		}
	}
}