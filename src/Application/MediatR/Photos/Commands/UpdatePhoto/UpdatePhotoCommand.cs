using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.UpdatePhoto
{
	public class UpdatePhotoCommand : IRequest<SlApiResponse<PhotosDto, object>>
	{
		public int Id { get; set; }
		public PhotosDto PhotosDto { get; set; }
	}

	public class UpdatePhotoCommandHandler : BaseRequestHandler, IRequestHandler<UpdatePhotoCommand, SlApiResponse<PhotosDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PhotosDto, object> _response;

		public UpdatePhotoCommandHandler(
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
			UpdatePhotoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PhotoRepo.UpdateDtoById(
				request.Id,
				request.PhotosDto,
				cancellationToken
			);
		}
	}
}