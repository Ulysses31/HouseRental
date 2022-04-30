using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.CreateGoogleMapPlace
{
	public class CreateGoogleMapPlaceCommand : IRequest<SlApiResponse<GoogleMapPlaceDto, object>>
	{
		public GoogleMapPlaceDto GoogleMapPlaceDto { get; set; }
	}

	public class CreateGoogleMapPlaceCommandHandler : BaseRequestHandler, IRequestHandler<CreateGoogleMapPlaceCommand, SlApiResponse<GoogleMapPlaceDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<GoogleMapPlaceDto, object> _response;

		public CreateGoogleMapPlaceCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<GoogleMapPlaceDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> Handle(
			CreateGoogleMapPlaceCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.GoogleMapPlaceRepo.AddDto(
				request.GoogleMapPlaceDto,
				cancellationToken
			);
		}
	}
}