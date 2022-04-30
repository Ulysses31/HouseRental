using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Commands.UpdateSuitableFor
{
	public class UpdateSuitableForCommand : IRequest<SlApiResponse<SuitableForDto, object>>
	{
		public int Id { get; set; }
		public SuitableForDto SuitableForDto { get; set; }
	}

	public class UpdateSuitableForCommandHandler : BaseRequestHandler, IRequestHandler<UpdateSuitableForCommand, SlApiResponse<SuitableForDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<SuitableForDto, object> _response;

		public UpdateSuitableForCommandHandler(
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
			UpdateSuitableForCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.SuitableForRepo.UpdateDtoById(
				request.Id,
				request.SuitableForDto,
				cancellationToken
			);
		}
	}
}