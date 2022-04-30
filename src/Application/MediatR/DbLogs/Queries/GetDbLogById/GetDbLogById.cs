//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Application.Common.Models.Responses;
//using CleanArchitecture.Domain.DTOs;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CleanArchitecture.Application.MediatR.DbLogs.Queries.GetDbLogById
//{
//	public class GetDbLogById : IRequest<SlApiResponse<DbLogDto, object>>
//	{
//		public int Id { get; set; }
//	}

//	public class GetDbLogByIdHandler : IRequestHandler<GetDbLogById, SlApiResponse<DbLogDto, object>>
//	{
//		private readonly IApplicationDbContext _context;
//		private readonly IMapper _mapper;
//		private readonly SlApiResponse<DbLogDto, object> _response;

//		public GetDbLogByIdHandler(
//			IApplicationDbContext context,
//			IMapper mapper,
//			SlApiResponse<DbLogDto, object> response
//		)
//		{
//			_context = context;
//			_mapper = mapper;
//			_response = response;
//		}

//		public async Task<SlApiResponse<DbLogDto, object>> Handle(
//			GetDbLogById request,
//			CancellationToken cancellationToken
//		)
//		{
//			try
//			{
//				var result = await _context.DbLogs
//						.Where(t => t.DbLogId == request.Id)
//						.ProjectTo<DbLogDto>(_mapper.ConfigurationProvider)
//						.FirstOrDefaultAsync(cancellationToken);

//				_response.Data = result;
//			}
//			catch (System.Exception e)
//			{
//				_response.IsError = true;
//				_response.Messages = new List<SlApiMessage>() {
//						new SlApiMessage() {
//							MessageType = Domain.Enums.SlApiMessageTypeEnum.Error,
//							Message = e.Message
//						}
//					};
//				//throw new System.Exception(e.Message);
//			}

//			return _response;
//		}
//	}
//}