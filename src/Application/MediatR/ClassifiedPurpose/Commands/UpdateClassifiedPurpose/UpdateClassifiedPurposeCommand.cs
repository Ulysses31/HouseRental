using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.UpdateClassifiedPurpose
{
	public class UpdateClassifiedPurposeCommand : IRequest<SlApiResponse<ClassifiedPurposeDto, object>>
	{
		public int Id { get; set; }
		public ClassifiedPurposeDto ClassifiedPurposeDto { get; set; }
	}

	public class UpdateClassifiedPurposeCommandHandler : BaseRequestHandler, IRequestHandler<UpdateClassifiedPurposeCommand, SlApiResponse<ClassifiedPurposeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedPurposeDto, object> _response;

		public UpdateClassifiedPurposeCommandHandler(
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
			UpdateClassifiedPurposeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedPurposeRepo.UpdateDtoById(
				request.Id,
				request.ClassifiedPurposeDto,
				cancellationToken
			);
		}
	}
}