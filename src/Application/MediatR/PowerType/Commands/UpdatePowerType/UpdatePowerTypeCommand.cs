using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.UpdatePowerType
{
	public class UpdatePowerTypeCommand : IRequest<SlApiResponse<PowerTypeDto, object>>
	{
		public int Id { get; set; }
		public PowerTypeDto PowerTypeDto { get; set; }
	}

	public class UpdatePowerTypeCommandHandler : BaseRequestHandler, IRequestHandler<UpdatePowerTypeCommand, SlApiResponse<PowerTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PowerTypeDto, object> _response;

		public UpdatePowerTypeCommandHandler(
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
			UpdatePowerTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PowerTypeRepo.UpdateDtoById(
				request.Id,
				request.PowerTypeDto,
				cancellationToken
			);
		}
	}
}