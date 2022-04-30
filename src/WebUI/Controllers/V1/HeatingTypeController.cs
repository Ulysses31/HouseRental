using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.HeatingType.Commands.CreateHeatingType;
using CleanArchitecture.Application.MediatR.HeatingType.Commands.DeleteHeatingType;
using CleanArchitecture.Application.MediatR.HeatingType.Commands.DisableEnableHeatingType;
using CleanArchitecture.Application.MediatR.HeatingType.Commands.UpdateHeatingType;
using CleanArchitecture.Application.MediatR.HeatingType.Queries.GetHeatingTypeById;
using CleanArchitecture.Application.MediatR.HeatingType.Queries.GetHeatingTypeWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// HeatingTypeController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class HeatingTypeController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HeatingTypeController"/> class.
		/// </summary>
		public HeatingTypeController()
		{
		}

		/// <summary>
		/// Gets the database HeatingType with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList HeatingTypeDto</returns>
		/// <response code="200">PaginatedList HeatingTypeDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<HeatingTypeDto>, object>>> GetHeatingTypeWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetHeatingTypeWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified HeatingType.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse HeatingTypeDto></returns>
		/// <response code = "200" > PaginatedList HeatingTypeDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<HeatingTypeDto, object>> GetHeatingTypeById(
				int id
		)
		{
			return await Mediator.Send(
				new GetHeatingTypeByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified HeatingType
		/// </summary>
		/// <param name="id"></param>
		/// <param name="HeatingTypeDto">HeatingTypeDto</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<HeatingTypeDto, object>> UpdateHeatingType(
				int id,
				HeatingTypeDto HeatingTypeDto
		)
		{
			return await Mediator.Send(
				new UpdateHeatingTypeCommand()
				{
					Id = id,
					HeatingTypeDto = HeatingTypeDto
				}
			);
		}

		/// <summary>
		/// Create a new HeatingType
		/// </summary>
		/// <param name="HeatingTypeDto">HeatingTypeDto</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<HeatingTypeDto, object>> CreateHeatingType(
				HeatingTypeDto HeatingTypeDto
		)
		{
			return await Mediator.Send(
				new CreateHeatingTypeCommand()
				{
					HeatingTypeDto = HeatingTypeDto
				}
			);
		}

		/// <summary>
		/// Delete the specified HeatingType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<HeatingTypeDto, object>> DeleteHeatingType(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteHeatingTypeCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified HeatingType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse HeatingTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableHeatingType/{id}")]
		public async Task<SlApiResponse<HeatingTypeDto, object>> DisableEnableHeatingType(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableHeatingTypeCommand()
				{
					Id = id
				}
			);
		}
	}
}