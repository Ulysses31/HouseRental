using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.DisableEnableClassifiedPurpose
{
	public class DisableEnableClassifiedPurposeCommand : IRequest<SlApiResponse<ClassifiedPurposeDto, object>>
	{
		public int Id { get; set; }
	}

	public class DisableEnableClassifiedPurposeCommandHandler : BaseRequestHandler, IRequestHandler<DisableEnableClassifiedPurposeCommand, SlApiResponse<ClassifiedPurposeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedPurposeDto, object> _response;

		public DisableEnableClassifiedPurposeCommandHandler(
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
			DisableEnableClassifiedPurposeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedPurposeRepo.DisableEnableDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}