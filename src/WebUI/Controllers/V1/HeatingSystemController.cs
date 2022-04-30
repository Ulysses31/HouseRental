using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.HeatingSystem.Commands.CreateHeatingSystem;
using CleanArchitecture.Application.MediatR.HeatingSystem.Commands.DeleteHeatingSystem;
using CleanArchitecture.Application.MediatR.HeatingSystem.Commands.DisableEnableHeatingSystem;
using CleanArchitecture.Application.MediatR.HeatingSystem.Commands.UpdateHeatingSystem;
using CleanArchitecture.Application.MediatR.HeatingSystem.Queries.GetHeatingSystemById;
using CleanArchitecture.Application.MediatR.HeatingSystem.Queries.GetHeatingSystemWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// HeatingSystemController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class HeatingSystemController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HeatingSystemController"/> class.
		/// </summary>
		public HeatingSystemController()
		{
		}

		/// <summary>
		/// Gets the database HeatingSystem with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList HeatingSystemDto</returns>
		/// <response code="200">PaginatedList HeatingSystemDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<HeatingSystemDto>, object>>> GetHeatingSystemWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetHeatingSystemWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified HeatingSystem.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse HeatingSystemDto></returns>
		/// <response code = "200" > PaginatedList HeatingSystemDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<HeatingSystemDto, object>> GetHeatingSystemById(
				int id
		)
		{
			return await Mediator.Send(
				new GetHeatingSystemByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified HeatingSystem
		/// </summary>
		/// <param name="id"></param>
		/// <param name="HeatingSystemDto">HeatingSystemDto</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<HeatingSystemDto, object>> UpdateHeatingSystem(
				int id,
				HeatingSystemDto HeatingSystemDto
		)
		{
			return await Mediator.Send(
				new UpdateHeatingSystemCommand()
				{
					Id = id,
					HeatingSystemDto = HeatingSystemDto
				}
			);
		}

		/// <summary>
		/// Create a new HeatingSystem
		/// </summary>
		/// <param name="HeatingSystemDto">HeatingSystemDto</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<HeatingSystemDto, object>> CreateHeatingSystem(
				HeatingSystemDto HeatingSystemDto
		)
		{
			return await Mediator.Send(
				new CreateHeatingSystemCommand()
				{
					HeatingSystemDto = HeatingSystemDto
				}
			);
		}

		/// <summary>
		/// Delete the specified HeatingSystem
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<HeatingSystemDto, object>> DeleteHeatingSystem(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteHeatingSystemCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified HeatingSystem
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse HeatingSystemDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableHeatingSystem/{id}")]
		public async Task<SlApiResponse<HeatingSystemDto, object>> DisableEnableHeatingSystem(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableHeatingSystemCommand()
				{
					Id = id
				}
			);
		}
	}
}