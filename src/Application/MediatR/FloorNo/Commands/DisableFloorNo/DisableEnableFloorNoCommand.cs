﻿using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.FloorNo.Commands.DisableEnableFloorNo
{
	public class DisableEnableFloorNoCommand : IRequest<SlApiResponse<FloorNoDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableFloorNoCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableFloorNoCommand, SlApiResponse<FloorNoDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<FloorNoDto, object> _response;

		public DisableEnableFloorNoCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<FloorNoDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<FloorNoDto, object>> Handle(
			DisableEnableFloorNoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.FloorNoRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}