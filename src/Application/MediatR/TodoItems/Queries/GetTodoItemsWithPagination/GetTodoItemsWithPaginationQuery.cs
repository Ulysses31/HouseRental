//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using CleanArchitecture.Application.Common.Interfaces;
//using CleanArchitecture.Application.Common.Mappings;
//using CleanArchitecture.Application.Common.Models;
//using CleanArchitecture.Domain.DTOs;
//using CleanArchitecture.Domain.Entities;
//using MediatR;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CleanArchitecture.Application.MediatR.TodoItems.Queries.GetTodoItemsWithPagination
//{
//	public class GetTodoItemsWithPaginationQuery : IRequest<PaginatedList<TodoItemBriefDto>>
//	{
//		public int ListId { get; set; }
//		public int PageNumber { get; set; } = 1;
//		public int PageSize { get; set; } = 10;
//	}

//	public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetTodoItemsWithPaginationQuery, PaginatedList<TodoItemBriefDto>>
//	{
//		private readonly IApplicationDbContext _context;
//		private readonly IMapper _mapper;

//		public GetTodoItemsWithPaginationQueryHandler(
//			IApplicationDbContext context, 
//			IMapper mapper
//		)
//		{
//			_context = context;
//			_mapper = mapper;
//		}

//		public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetTodoItemsWithPaginationQuery request, CancellationToken cancellationToken)
//		{
//			return null;
//			//try
//			//{

//			//	var result = await _context.TodoItems
//			//			.Where(x => x.ListId == request.ListId)
//			//			.OrderBy(x => x.Title)
//			//			.ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
//			//			.PaginatedListAsync(request.PageNumber, request.PageSize);


//			//	return result;
//			//}
//			//catch (System.Exception e)
//			//{
//			//	throw new System.Exception(e.Message);
//			//}
//		}
//	}
//}