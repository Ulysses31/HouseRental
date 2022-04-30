//using CleanArchitecture.Application.Common.Models;
//using CleanArchitecture.Application.Common.Models.Responses;
//using CleanArchitecture.Application.MediatR.DbLogs.Queries.GetDbLogById;
//using CleanArchitecture.Application.MediatR.DbLogs.Queries.GetDbLogsWithPagination;
//using CleanArchitecture.Domain.DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace CleanArchitecture.WebUI.Controllers.V1_1
//{
//	/// <summary>
//	/// LogsController controller
//	/// </summary>
//	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
//	[ApiController]
//	[ApiVersion("1.1")]
//	[Route("api/v{version:apiVersion}/[controller]")]
//	[Consumes("application/json", "application/xml")]
//	[Produces("application/json", "application/xml")]
//	public class LogsController : ApiControllerBase
//	{
//		/// <summary>
//		/// Initializes a new instance of the <see cref="LogsController"/> class.
//		/// </summary>
//		public LogsController()
//		{
//		}

//		// GET: api/v1.1/<LogsController>
//		/// <summary>
//		/// Gets the database logs with pagination.
//		/// </summary>
//		/// <param name="query">The query.</param>
//		/// <returns>PaginatedList DbLogDto</returns>
//		/// <response code="200">PaginatedList DbLogDto</response>
//		/// <response code="401">Unauthorized</response>
//		/// <response code="400">Bad Request</response>
//		/// <response code="404">Not Found</response>
//		/// <response code="406">Not Acceptable</response>
//		/// <response code="500">Internal Server Error</response>
//		[ProducesResponseType(StatusCodes.Status200OK)]
//		[ProducesResponseType(StatusCodes.Status404NotFound)]
//		[MapToApiVersion("1.1")]
//		[HttpGet]
//		public async Task<ActionResult<SlApiResponse<PaginatedList<DbLogDto>, object>>> GetDbLogsWithPagination(
//			[FromQuery] GetDbLogsWithPaginationQuery query
//		)
//		{
//			return await Mediator.Send(query);
//		}

//		// GET api/v1.1/<LogsController>/5
//		/// <summary>
//		/// Gets the specified identifier.
//		/// </summary>
//		/// <param name="id">The identifier.</param>
//		/// <returns>SlApiResponse DbLogDto</returns>
//		/// <response code="200">PaginatedList DbLogDto</response>
//		/// <response code="401">Unauthorized</response>
//		/// <response code="400">Bad Request</response>
//		/// <response code="404">Not Found</response>
//		/// <response code="406">Not Acceptable</response>
//		/// <response code="500">Internal Server Error</response>
//		[ProducesResponseType(StatusCodes.Status200OK)]
//		[ProducesResponseType(StatusCodes.Status404NotFound)]
//		[MapToApiVersion("1.1")]
//		[HttpGet("{id}")]
//		public async Task<SlApiResponse<DbLogDto, object>> Get(int id)
//		{
//			return await Mediator.Send(new GetDbLogById { Id = id });
//		}
//	}
//}