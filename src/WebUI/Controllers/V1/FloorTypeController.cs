using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.FloorType.Commands.CreateFloorType;
using CleanArchitecture.Application.MediatR.FloorType.Commands.DeleteFloorType;
using CleanArchitecture.Application.MediatR.FloorType.Commands.DisableEnableFloorType;
using CleanArchitecture.Application.MediatR.FloorType.Commands.UpdateFloorType;
using CleanArchitecture.Application.MediatR.FloorType.Queries.GetFloorTypeById;
using CleanArchitecture.Application.MediatR.FloorType.Queries.GetFloorTypeWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// FloorTypeController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class FloorTypeController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FloorTypeController"/> class.
		/// </summary>
		public FloorTypeController()
		{
		}

		/// <summary>
		/// Gets the database FloorType with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList FloorTypeDto</returns>
		/// <response code="200">PaginatedList FloorTypeDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<FloorTypeDto>, object>>> GetFloorTypeWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetFloorTypeWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified FloorType.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse FloorTypeDto></returns>
		/// <response code = "200" > PaginatedList FloorTypeDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<FloorTypeDto, object>> GetFloorTypeById(
				int id
		)
		{
			return await Mediator.Send(
				new GetFloorTypeByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified FloorType
		/// </summary>
		/// <param name="id"></param>
		/// <param name="FloorTypeDto">FloorTypeDto</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<FloorTypeDto, object>> UpdateFloorType(
				int id,
				FloorTypeDto FloorTypeDto
		)
		{
			return await Mediator.Send(
				new UpdateFloorTypeCommand()
				{
					Id = id,
					FloorTypeDto = FloorTypeDto
				}
			);
		}

		/// <summary>
		/// Create a new FloorType
		/// </summary>
		/// <param name="FloorTypeDto">FloorTypeDto</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<FloorTypeDto, object>> CreateFloorType(
				FloorTypeDto FloorTypeDto
		)
		{
			return await Mediator.Send(
				new CreateFloorTypeCommand()
				{
					FloorTypeDto = FloorTypeDto
				}
			);
		}

		/// <summary>
		/// Delete the specified FloorType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<FloorTypeDto, object>> DeleteFloorType(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteFloorTypeCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified FloorType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse FloorTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableFloorType/{id}")]
		public async Task<SlApiResponse<FloorTypeDto, object>> DisableEnableFloorType(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableFloorTypeCommand()
				{
					Id = id
				}
			);
		}
	}
}