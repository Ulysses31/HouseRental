using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.UpdateClassifiedCharacteristics
{
	public class UpdateClassifiedCharacteristicsCommand : IRequest<SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		public int Id { get; set; }
		public ClassifiedCharacteristicsDto ClassifiedCharacteristicsDto { get; set; }
	}

	public class UpdateClassifiedCharacteristicsCommandHandler : BaseRequestHandler, IRequestHandler<UpdateClassifiedCharacteristicsCommand, SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedCharacteristicsDto, object> _response;

		public UpdateClassifiedCharacteristicsCommandHandler(
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
			UpdateClassifiedCharacteristicsCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedCharacteristicsRepo.UpdateDtoById(
				request.Id,
				request.ClassifiedCharacteristicsDto,
				cancellationToken
			);
		}
	}
}