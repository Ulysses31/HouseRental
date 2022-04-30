using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Commands.CreateHeatingSystem
{
	public class CreateHeatingSystemCommand : IRequest<SlApiResponse<HeatingSystemDto, object>>
	{
		public HeatingSystemDto HeatingSystemDto { get; set; }
	}

	public class CreateHeatingSystemCommandHandler : BaseRequestHandler, IRequestHandler<CreateHeatingSystemCommand, SlApiResponse<HeatingSystemDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<HeatingSystemDto, object> _response;

		public CreateHeatingSystemCommandHandler(
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
			CreateHeatingSystemCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingSystemRepo.AddDto(
				request.HeatingSystemDto,
				cancellationToken
			);
		}
	}
}