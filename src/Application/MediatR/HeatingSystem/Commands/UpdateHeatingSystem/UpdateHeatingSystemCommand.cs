using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Commands.UpdateHeatingSystem
{
	public class UpdateHeatingSystemCommand : IRequest<SlApiResponse<HeatingSystemDto, object>>
	{
		public int Id { get; set; }
		public HeatingSystemDto HeatingSystemDto { get; set; }
	}

	public class UpdateHeatingSystemCommandHandler : BaseRequestHandler, IRequestHandler<UpdateHeatingSystemCommand, SlApiResponse<HeatingSystemDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<HeatingSystemDto, object> _response;

		public UpdateHeatingSystemCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<HeatingSystemDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<HeatingSystemDto, object>> Handle(
			UpdateHeatingSystemCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingSystemRepo.UpdateDtoById(
				request.Id,
				request.HeatingSystemDto,
				cancellationToken
			);
		}
	}
}