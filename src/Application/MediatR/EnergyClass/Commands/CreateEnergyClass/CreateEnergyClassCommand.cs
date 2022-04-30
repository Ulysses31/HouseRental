using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Commands.CreateEnergyClass
{
	public class CreateEnergyClassCommand : IRequest<SlApiResponse<EnergyClassDto, object>>
	{
		public EnergyClassDto EnergyClassDto { get; set; }
	}

	public class CreateEnergyClassCommandHandler : BaseRequestHandler, IRequestHandler<CreateEnergyClassCommand, SlApiResponse<EnergyClassDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<EnergyClassDto, object> _response;

		public CreateEnergyClassCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<EnergyClassDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<EnergyClassDto, object>> Handle(
			CreateEnergyClassCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.EnergyClassRepo.AddDto(
				request.EnergyClassDto,
				cancellationToken
			);
		}
	}
}