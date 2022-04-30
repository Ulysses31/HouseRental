using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Commands.UpdateClassifiedType
{
	public class UpdateClassifiedTypeCommand : IRequest<SlApiResponse<ClassifiedTypeDto, object>>
	{
		public int Id { get; set; }
		public ClassifiedTypeDto ClassifiedTypeDto { get; set; }
	}

	public class UpdateClassifiedTypeCommandHandler : BaseRequestHandler, IRequestHandler<UpdateClassifiedTypeCommand, SlApiResponse<ClassifiedTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedTypeDto, object> _response;

		public UpdateClassifiedTypeCommandHandler(
			IRepoManager repoManager,
			IMapper mapper,
			SlApiResponse<ClassifiedTypeDto, object> response
		) : base(repoManager, mapper)
		{
			this._repoManager = repoManager;
			this._mapper = mapper;
			this._response = response;
		}

		public async Task<SlApiResponse<ClassifiedTypeDto, object>> Handle(
			UpdateClassifiedTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedTypeRepo.UpdateDtoById(
				request.Id,
				request.ClassifiedTypeDto,
				cancellationToken
			);
		}
	}
}