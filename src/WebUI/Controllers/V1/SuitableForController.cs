using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.SuitableFor.Commands.CreateSuitableFor;
using CleanArchitecture.Application.MediatR.SuitableFor.Commands.DeleteSuitableFor;
using CleanArchitecture.Application.MediatR.SuitableFor.Commands.DisableEnableSuitableFor;
using CleanArchitecture.Application.MediatR.SuitableFor.Commands.UpdateSuitableFor;
using CleanArchitecture.Application.MediatR.SuitableFor.Queries.GetSuitableForById;
using CleanArchitecture.Application.MediatR.SuitableFor.Queries.GetSuitableForWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// SuitableForController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class SuitableForController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SuitableForController"/> class.
		/// </summary>
		public SuitableForController()
		{
		}

		/// <summary>
		/// Gets the database SuitableFor with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList SuitableForDto</returns>
		/// <response code="200">PaginatedList SuitableForDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<SuitableForDto>, object>>> GetSuitableForWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetSuitableForWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified SuitableFor.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse SuitableForDto></returns>
		/// <response code = "200" > PaginatedList SuitableForDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<SuitableForDto, object>> GetSuitableForById(
				int id
		)
		{
			return await Mediator.Send(
				new GetSuitableForByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified SuitableFor
		/// </summary>
		/// <param name="id"></param>
		/// <param name="SuitableForDto">SuitableForDto</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<SuitableForDto, object>> UpdateSuitableFor(
				int id,
				SuitableForDto SuitableForDto
		)
		{
			return await Mediator.Send(
				new UpdateSuitableForCommand()
				{
					Id = id,
					SuitableForDto = SuitableForDto
				}
			);
		}

		/// <summary>
		/// Create a new SuitableFor
		/// </summary>
		/// <param name="SuitableForDto">SuitableForDto</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<SuitableForDto, object>> CreateSuitableFor(
				SuitableForDto SuitableForDto
		)
		{
			return await Mediator.Send(
				new CreateSuitableForCommand()
				{
					SuitableForDto = SuitableForDto
				}
			);
		}

		/// <summary>
		/// Delete the specified SuitableFor
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<SuitableForDto, object>> DeleteSuitableFor(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteSuitableForCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified SuitableFor
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse SuitableForDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableSuitableFor/{id}")]
		public async Task<SlApiResponse<SuitableForDto, object>> DisableEnableSuitableFor(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableSuitableForCommand()
				{
					Id = id
				}
			);
		}
	}
}