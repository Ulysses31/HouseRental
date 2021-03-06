using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.DeleteClassifiedCharacteristics
{
	public class DeleteClassifiedCharacteristicsCommand : IRequest<SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeleteClassifiedCharacteristicsCommandHandler : BaseRequestHandler, IRequestHandler<DeleteClassifiedCharacteristicsCommand, SlApiResponse<ClassifiedCharacteristicsDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedCharacteristicsDto, object> _response;

		public DeleteClassifiedCharacteristicsCommandHandler(
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
			DeleteClassifiedCharacteristicsCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedCharacteristicsRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}