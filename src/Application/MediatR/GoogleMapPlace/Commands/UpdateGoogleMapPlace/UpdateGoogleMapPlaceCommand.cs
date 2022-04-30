using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.UpdateGoogleMapPlace
{
	public class UpdateGoogleMapPlaceCommand : IRequest<SlApiResponse<GoogleMapPlaceDto, object>>
	{
		public int Id { get; set; }
		public GoogleMapPlaceDto GoogleMapPlaceDto { get; set; }
	}

	public class UpdateGoogleMapPlaceCommandHandler : BaseRequestHandler, IRequestHandler<UpdateGoogleMapPlaceCommand, SlApiResponse<GoogleMapPlaceDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<GoogleMapPlaceDto, object> _response;

		public UpdateGoogleMapPlaceCommandHandler(
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
			UpdateGoogleMapPlaceCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.GoogleMapPlaceRepo.UpdateDtoById(
				request.Id,
				request.GoogleMapPlaceDto,
				cancellationToken
			);
		}
	}
}