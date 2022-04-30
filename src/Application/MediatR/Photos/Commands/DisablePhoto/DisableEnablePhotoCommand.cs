using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.DisableEnablePhoto
{
	public class DisableEnablePhotoCommand : IRequest<SlApiResponse<PhotosDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnablePhotoCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnablePhotoCommand, SlApiResponse<PhotosDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PhotosDto, object> _response;

		public DisableEnablePhotoCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<PhotosDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<PhotosDto, object>> Handle(
			DisableEnablePhotoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PhotoRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}