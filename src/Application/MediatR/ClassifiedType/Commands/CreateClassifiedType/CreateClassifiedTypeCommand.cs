using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Commands.CreateClassifiedType
{
	public class CreateClassifiedTypeCommand : IRequest<SlApiResponse<ClassifiedTypeDto, object>>
	{
		public ClassifiedTypeDto ClassifiedTypeDto { get; set; }
	}

	public class CreateClassifiedTypeCommandHandler : BaseRequestHandler, IRequestHandler<CreateClassifiedTypeCommand, SlApiResponse<ClassifiedTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedTypeDto, object> _response;

		public CreateClassifiedTypeCommandHandler(
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
			CreateClassifiedTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedTypeRepo.AddDto(
				request.ClassifiedTypeDto,
				cancellationToken
			);
		}
	}
}