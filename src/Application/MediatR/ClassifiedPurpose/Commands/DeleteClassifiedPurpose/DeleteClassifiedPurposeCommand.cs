using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.DeleteClassifiedPurpose
{
	public class DeleteClassifiedPurposeCommand : IRequest<SlApiResponse<ClassifiedPurposeDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeleteClassifiedPurposeCommandHandler : BaseRequestHandler, IRequestHandler<DeleteClassifiedPurposeCommand, SlApiResponse<ClassifiedPurposeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedPurposeDto, object> _response;

		public DeleteClassifiedPurposeCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedPurposeDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> Handle(
			DeleteClassifiedPurposeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedPurposeRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}