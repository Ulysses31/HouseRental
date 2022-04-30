using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.PowerType.Commands.CreatePowerType;
using CleanArchitecture.Application.MediatR.PowerType.Commands.DeletePowerType;
using CleanArchitecture.Application.MediatR.PowerType.Commands.DisableEnablePowerType;
using CleanArchitecture.Application.MediatR.PowerType.Commands.UpdatePowerType;
using CleanArchitecture.Application.MediatR.PowerType.Queries.GetPowerTypeById;
using CleanArchitecture.Application.MediatR.PowerType.Queries.GetPowerTypeWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// PowerTypeController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class PowerTypeController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PowerTypeController"/> class.
		/// </summary>
		public PowerTypeController()
		{
		}

		/// <summary>
		/// Gets the database PowerType with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList PowerTypeDto</returns>
		/// <response code="200">PaginatedList PowerTypeDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<PowerTypeDto>, object>>> GetPowerTypeWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetPowerTypeWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified PowerType.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse PowerTypeDto></returns>
		/// <response code = "200" > PaginatedList PowerTypeDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<PowerTypeDto, object>> GetPowerTypeById(
				int id
		)
		{
			return await Mediator.Send(
				new GetPowerTypeByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified PowerType
		/// </summary>
		/// <param name="id"></param>
		/// <param name="PowerTypeDto">PowerTypeDto</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<PowerTypeDto, object>> UpdatePowerType(
				int id,
				PowerTypeDto PowerTypeDto
		)
		{
			return await Mediator.Send(
				new UpdatePowerTypeCommand()
				{
					Id = id,
					PowerTypeDto = PowerTypeDto
				}
			);
		}

		/// <summary>
		/// Create a new PowerType
		/// </summary>
		/// <param name="PowerTypeDto">PowerTypeDto</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<PowerTypeDto, object>> CreatePowerType(
				PowerTypeDto PowerTypeDto
		)
		{
			return await Mediator.Send(
				new CreatePowerTypeCommand()
				{
					PowerTypeDto = PowerTypeDto
				}
			);
		}

		/// <summary>
		/// Delete the specified PowerType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<PowerTypeDto, object>> DeletePowerType(
			int id
		)
		{
			return await Mediator.Send(
				new DeletePowerTypeCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified PowerType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse PowerTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnablePowerType/{id}")]
		public async Task<SlApiResponse<PowerTypeDto, object>> DisableEnablePowerType(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnablePowerTypeCommand()
				{
					Id = id
				}
			);
		}
	}
}