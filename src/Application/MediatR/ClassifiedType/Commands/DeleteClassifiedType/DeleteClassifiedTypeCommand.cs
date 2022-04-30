using AutoMapper;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.Repository.Interfaces;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Commands.DeleteClassifiedType
{
	public class DeleteClassifiedTypeCommand : IRequest<SlApiResponse<ClassifiedTypeDto, object>>
	{
		public int Id { get; set; }
	}

	public class DeleteClassifiedTypeCommandHandler : BaseRequestHandler, IRequestHandler<DeleteClassifiedTypeCommand, SlApiResponse<ClassifiedTypeDto, object>>
	{
		private readonly IRepoManager _repoManager;
		private readonly IMapper _mapper;
		private readonly SlApiResponse<ClassifiedTypeDto, object> _response;

		public DeleteClassifiedTypeCommandHandler(
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
			DeleteClassifiedTypeCommand request,
			CancellationToken cancellationToken
		)
		{
			return await this._repoManager.ClassifiedTypeRepo.DeleteDtoById(
				request.Id,
				cancellationToken
			);
		}
	}
}