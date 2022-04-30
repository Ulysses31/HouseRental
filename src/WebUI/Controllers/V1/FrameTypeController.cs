using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.FrameType.Commands.CreateFrameType;
using CleanArchitecture.Application.MediatR.FrameType.Commands.DeleteFrameType;
using CleanArchitecture.Application.MediatR.FrameType.Commands.DisableEnableFrameType;
using CleanArchitecture.Application.MediatR.FrameType.Commands.UpdateFrameType;
using CleanArchitecture.Application.MediatR.FrameType.Queries.GetFrameTypeById;
using CleanArchitecture.Application.MediatR.FrameType.Queries.GetFrameTypeWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// FrameTypeController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class FrameTypeController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FrameTypeController"/> class.
		/// </summary>
		public FrameTypeController()
		{
		}

		/// <summary>
		/// Gets the database FrameType with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList FrameTypeDto</returns>
		/// <response code="200">PaginatedList FrameTypeDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<FrameTypeDto>, object>>> GetFrameTypeWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetFrameTypeWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified FrameType.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse FrameTypeDto></returns>
		/// <response code = "200" > PaginatedList FrameTypeDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<FrameTypeDto, object>> GetFrameTypeById(
				int id
		)
		{
			return await Mediator.Send(
				new GetFrameTypeByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified FrameType
		/// </summary>
		/// <param name="id"></param>
		/// <param name="FrameTypeDto">FrameTypeDto</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<FrameTypeDto, object>> UpdateFrameType(
				int id,
				FrameTypeDto FrameTypeDto
		)
		{
			return await Mediator.Send(
				new UpdateFrameTypeCommand()
				{
					Id = id,
					FrameTypeDto = FrameTypeDto
				}
			);
		}

		/// <summary>
		/// Create a new FrameType
		/// </summary>
		/// <param name="FrameTypeDto">FrameTypeDto</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<FrameTypeDto, object>> CreateFrameType(
				FrameTypeDto FrameTypeDto
		)
		{
			return await Mediator.Send(
				new CreateFrameTypeCommand()
				{
					FrameTypeDto = FrameTypeDto
				}
			);
		}

		/// <summary>
		/// Delete the specified FrameType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<FrameTypeDto, object>> DeleteFrameType(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteFrameTypeCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified FrameType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse FrameTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableFrameType/{id}")]
		public async Task<SlApiResponse<FrameTypeDto, object>> DisableEnableFrameType(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableFrameTypeCommand()
				{
					Id = id
				}
			);
		}
	}
}