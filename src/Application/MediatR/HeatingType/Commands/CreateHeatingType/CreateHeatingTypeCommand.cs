using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingType.Commands.CreateHeatingType
{
	public class CreateHeatingTypeCommand : IRequest<SlApiResponse<HeatingTypeDto, object>>
	{
		public HeatingTypeDto HeatingTypeDto { get; set; }
	}

	public class CreateHeatingTypeCommandHandler : BaseRequestHandler, IRequestHandler<CreateHeatingTypeCommand, SlApiResponse<HeatingTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<HeatingTypeDto, object> _response;

		public CreateHeatingTypeCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<HeatingTypeDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<HeatingTypeDto, object>> Handle(
			CreateHeatingTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingTypeRepo.AddDto(
				request.HeatingTypeDto,
				cancellationToken
			);
		}
	}
}