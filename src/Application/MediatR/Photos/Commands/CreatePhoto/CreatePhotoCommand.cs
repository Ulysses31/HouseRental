using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.CreatePhoto
{
	public class CreatePhotoCommand : IRequest<SlApiResponse<PhotosDto, object>>
	{
		public PhotosDto PhotosDto { get; set; }
	}

	public class CreatePhotoCommandHandler : BaseRequestHandler, IRequestHandler<CreatePhotoCommand, SlApiResponse<PhotosDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PhotosDto, object> _response;

		public CreatePhotoCommandHandler(
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
			CreatePhotoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PhotoRepo.AddDto(
				request.PhotosDto,
				cancellationToken
			);
		}
	}
}