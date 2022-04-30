using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Commands.CreateSuitableFor
{
	public class CreateSuitableForCommand : IRequest<SlApiResponse<SuitableForDto, object>>
	{
		public SuitableForDto SuitableForDto { get; set; }
	}

	public class CreateSuitableForCommandHandler : BaseRequestHandler, IRequestHandler<CreateSuitableForCommand, SlApiResponse<SuitableForDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<SuitableForDto, object> _response;

		public CreateSuitableForCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<SuitableForDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<SuitableForDto, object>> Handle(
			CreateSuitableForCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.SuitableForRepo.AddDto(
				request.SuitableForDto,
				cancellationToken
			);
		}
	}
}