using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.DeletePowerType
{
	public class DeletePowerTypeCommand : IRequest<SlApiResponse<PowerTypeDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeletePowerTypeCommandHandler : BaseRequestHandler, IRequestHandler<DeletePowerTypeCommand, SlApiResponse<PowerTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PowerTypeDto, object> _response;

		public DeletePowerTypeCommandHandler(
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
			DeletePowerTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PowerTypeRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}