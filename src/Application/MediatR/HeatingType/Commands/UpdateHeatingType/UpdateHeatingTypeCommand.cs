using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.HeatingType.Commands.UpdateHeatingType
{
	public class UpdateHeatingTypeCommand : IRequest<SlApiResponse<HeatingTypeDto, object>>
	{
		public int Id { get; set; }
		public HeatingTypeDto HeatingTypeDto { get; set; }
	}

	public class UpdateHeatingTypeCommandHandler : BaseRequestHandler, IRequestHandler<UpdateHeatingTypeCommand, SlApiResponse<HeatingTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<HeatingTypeDto, object> _response;

		public UpdateHeatingTypeCommandHandler(
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
			UpdateHeatingTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.HeatingTypeRepo.UpdateDtoById(
				request.Id,
				request.HeatingTypeDto,
				cancellationToken
			);
		}
	}
}