using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.CreateClassifiedPurpose
{
	public class CreateClassifiedPurposeCommand : IRequest<SlApiResponse<ClassifiedPurposeDto, object>>
	{
		public ClassifiedPurposeDto ClassifiedPurposeDto { get; set; }
	}

	public class CreateClassifiedPurposeCommandHandler : BaseRequestHandler, IRequestHandler<CreateClassifiedPurposeCommand, SlApiResponse<ClassifiedPurposeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedPurposeDto, object> _response;

		public CreateClassifiedPurposeCommandHandler(
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
			CreateClassifiedPurposeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedPurposeRepo.AddDto(
				request.ClassifiedPurposeDto,
				cancellationToken
			);
		}
	}
}