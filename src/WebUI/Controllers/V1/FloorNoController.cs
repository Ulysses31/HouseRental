using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.FloorNo.Commands.CreateFloorNo;
using CleanArchitecture.Application.MediatR.FloorNo.Commands.DeleteFloorNo;
using CleanArchitecture.Application.MediatR.FloorNo.Commands.DisableEnableFloorNo;
using CleanArchitecture.Application.MediatR.FloorNo.Commands.UpdateFloorNo;
using CleanArchitecture.Application.MediatR.FloorNo.Queries.GetFloorNoById;
using CleanArchitecture.Application.MediatR.FloorNo.Queries.GetFloorNoWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// FloorNoController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class FloorNoController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FloorNoController"/> class.
		/// </summary>
		public FloorNoController()
		{
		}

		/// <summary>
		/// Gets the database FloorNo with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList FloorNoDto</returns>
		/// <response code="200">PaginatedList FloorNoDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<FloorNoDto>, object>>> GetFloorNoWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetFloorNoWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified FloorNo.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse FloorNoDto></returns>
		/// <response code = "200" > PaginatedList FloorNoDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<FloorNoDto, object>> GetFloorNoById(
				int id
		)
		{
			return await Mediator.Send(
				new GetFloorNoByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified FloorNo
		/// </summary>
		/// <param name="id"></param>
		/// <param name="FloorNoDto">FloorNoDto</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<FloorNoDto, object>> UpdateFloorNo(
				int id,
				FloorNoDto FloorNoDto
		)
		{
			return await Mediator.Send(
				new UpdateFloorNoCommand()
				{
					Id = id,
					FloorNoDto = FloorNoDto
				}
			);
		}

		/// <summary>
		/// Create a new FloorNo
		/// </summary>
		/// <param name="FloorNoDto">FloorNoDto</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<FloorNoDto, object>> CreateFloorNo(
				FloorNoDto FloorNoDto
		)
		{
			return await Mediator.Send(
				new CreateFloorNoCommand()
				{
					FloorNoDto = FloorNoDto
				}
			);
		}

		/// <summary>
		/// Delete the specified FloorNo
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<FloorNoDto, object>> DeleteFloorNo(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteFloorNoCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified FloorNo
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse FloorNoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableFloorNo/{id}")]
		public async Task<SlApiResponse<FloorNoDto, object>> DisableEnableFloorNo(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableFloorNoCommand()
				{
					Id = id
				}
			);
		}
	}
}