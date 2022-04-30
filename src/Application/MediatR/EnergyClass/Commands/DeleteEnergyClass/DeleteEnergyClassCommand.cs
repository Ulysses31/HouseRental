using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Commands.DeleteEnergyClass
{
	public class DeleteEnergyClassCommand : IRequest<SlApiResponse<EnergyClassDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeleteEnergyClassCommandHandler : BaseRequestHandler, IRequestHandler<DeleteEnergyClassCommand, SlApiResponse<EnergyClassDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<EnergyClassDto, object> _response;

		public DeleteEnergyClassCommandHandler(
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
			DeleteEnergyClassCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.EnergyClassRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}