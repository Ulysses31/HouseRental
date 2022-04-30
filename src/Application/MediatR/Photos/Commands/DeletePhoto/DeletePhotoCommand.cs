using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.DeletePhoto
{
	public class DeletePhotoCommand : IRequest<SlApiResponse<PhotosDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeletePhotoCommandHandler : BaseRequestHandler, IRequestHandler<DeletePhotoCommand, SlApiResponse<PhotosDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<PhotosDto, object> _response;

		public DeletePhotoCommandHandler(
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
			DeletePhotoCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.PhotoRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}