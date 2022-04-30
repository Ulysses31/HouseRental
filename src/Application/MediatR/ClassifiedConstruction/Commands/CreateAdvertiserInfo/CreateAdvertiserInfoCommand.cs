using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.CreateClassifiedConstruction
{
	public class CreateClassifiedConstructionCommand : IRequest<SlApiResponse<ClassifiedConstructionDto, object>>
	{
		public ClassifiedConstructionDto ClassifiedConstructionDto { get; set; }
	}

	public class CreateClassifiedConstructionCommandHandler : BaseRequestHandler, IRequestHandler<CreateClassifiedConstructionCommand, SlApiResponse<ClassifiedConstructionDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedConstructionDto, object> _response;

		public CreateClassifiedConstructionCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedConstructionDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> Handle(
			CreateClassifiedConstructionCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedConstructionRepo.AddDto(
				request.ClassifiedConstructionDto,
				cancellationToken
			);
		}
	}
}