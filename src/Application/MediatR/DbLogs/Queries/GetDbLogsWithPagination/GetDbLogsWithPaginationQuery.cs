//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Application.Common.Mappings;
//using CleanArchitecture.Application.Common.Models;
//using CleanArchitecture.Application.Common.Models.Responses;
//using CleanArchitecture.Domain.DTOs;
//using MediatR;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CleanArchitecture.Application.MediatR.DbLogs.Queries.GetDbLogsWithPagination
//{
//	public class GetDbLogsWithPaginationQuery : IRequest<SlApiResponse<PaginatedList<DbLogDto>, object>>
//	{
//		public int ListId { get; set; } = 0;
//		public int PageNumber { get; set; } = 1;
//		public int PageSize { get; set; } = 10;
//	}

//	public class GetDbLogsWithPaginationQueryHandler : IRequestHandler<GetDbLogsWithPaginationQuery, SlApiResponse<PaginatedList<DbLogDto>, object>>
//	{
//		private readonly IApplicationDbContext _context;
//		private readonly IMapper _mapper;
//		private readonly SlApiResponse<PaginatedList<DbLogDto>, object> _response;

//		public GetDbLogsWithPaginationQueryHandler(
//			IApplicationDbContext context,
//			IMapper mapper,
//			SlApiResponse<PaginatedList<DbLogDto>, object> response
//		)
//		{
//			_context = context;
//			_mapper = mapper;
//			_response = response;
//		}

//		public async Task<SlApiResponse<PaginatedList<DbLogDto>, object>> Handle(
//			GetDbLogsWithPaginationQuery request,
//			CancellationToken cancellationToken
//		)
//		{
//			try
//			{
//				var result = await _context.DbLogs
//					//.Where(x => x.Id == request.ListId)
//					.OrderBy(x => x.DbLogId)
//					.ProjectTo<DbLogDto>(_mapper.ConfigurationProvider)
//					.PaginatedListAsync(request.PageNumber, request.PageSize);

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