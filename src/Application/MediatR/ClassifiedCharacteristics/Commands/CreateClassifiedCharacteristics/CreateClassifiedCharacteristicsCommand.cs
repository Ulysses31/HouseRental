using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.CreateClassifiedCharacteristics
{
	public class CreateClassifiedCharacteristicsCommand : IRequest<SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		public ClassifiedCharacteristicsDto ClassifiedCharacteristicsDto { get; set; }
	}

	public class CreateClassifiedCharacteristicsCommandHandler : BaseRequestHandler, IRequestHandler<CreateClassifiedCharacteristicsCommand, SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedCharacteristicsDto, object> _response;

		public CreateClassifiedCharacteristicsCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedCharacteristicsDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> Handle(
			CreateClassifiedCharacteristicsCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedCharacteristicsRepo.AddDto(
				request.ClassifiedCharacteristicsDto,
				cancellationToken
			);
		}
	}
}