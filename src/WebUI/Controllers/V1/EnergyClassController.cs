using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.EnergyClass.Commands.CreateEnergyClass;
using CleanArchitecture.Application.MediatR.EnergyClass.Commands.DeleteEnergyClass;
using CleanArchitecture.Application.MediatR.EnergyClass.Commands.DisableEnableEnergyClass;
using CleanArchitecture.Application.MediatR.EnergyClass.Commands.UpdateEnergyClass;
using CleanArchitecture.Application.MediatR.EnergyClass.Queries.GetEnergyClassById;
using CleanArchitecture.Application.MediatR.EnergyClass.Queries.GetEnergyClassWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// EnergyClassController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class EnergyClassController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EnergyClassController"/> class.
		/// </summary>
		public EnergyClassController()
		{
		}

		/// <summary>
		/// Gets the database EnergyClass with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList EnergyClassDto</returns>
		/// <response code="200">PaginatedList EnergyClassDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<EnergyClassDto>, object>>> GetEnergyClassWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetEnergyClassWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified EnergyClass.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse EnergyClassDto></returns>
		/// <response code = "200" > PaginatedList EnergyClassDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<EnergyClassDto, object>> GetEnergyClassById(
				int id
		)
		{
			return await Mediator.Send(
				new GetEnergyClassByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified EnergyClass
		/// </summary>
		/// <param name="id"></param>
		/// <param name="EnergyClassDto">EnergyClassDto</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<EnergyClassDto, object>> UpdateEnergyClass(
				int id,
				EnergyClassDto EnergyClassDto
		)
		{
			return await Mediator.Send(
				new UpdateEnergyClassCommand()
				{
					Id = id,
					EnergyClassDto = EnergyClassDto
				}
			);
		}

		/// <summary>
		/// Create a new EnergyClass
		/// </summary>
		/// <param name="EnergyClassDto">EnergyClassDto</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<EnergyClassDto, object>> CreateEnergyClass(
				EnergyClassDto EnergyClassDto
		)
		{
			return await Mediator.Send(
				new CreateEnergyClassCommand()
				{
					EnergyClassDto = EnergyClassDto
				}
			);
		}

		/// <summary>
		/// Delete the specified EnergyClass
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<EnergyClassDto, object>> DeleteEnergyClass(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteEnergyClassCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified EnergyClass
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse EnergyClassDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableEnergyClass/{id}")]
		public async Task<SlApiResponse<EnergyClassDto, object>> DisableEnableEnergyClass(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableEnergyClassCommand()
				{
					Id = id
				}
			);
		}
	}
}