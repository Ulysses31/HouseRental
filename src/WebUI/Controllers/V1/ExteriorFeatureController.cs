using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.CreateExteriorFeature;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.DeleteExteriorFeature;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.DisableEnableExteriorFeature;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.UpdateExteriorFeature;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Queries.GetExteriorFeatureById;
using CleanArchitecture.Application.MediatR.ExteriorFeature.Queries.GetExteriorFeatureWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// ExteriorFeatureController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class ExteriorFeatureController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExteriorFeatureController"/> class.
		/// </summary>
		public ExteriorFeatureController()
		{
		}

		/// <summary>
		/// Gets the database ExteriorFeature with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList ExteriorFeatureDto</returns>
		/// <response code="200">PaginatedList ExteriorFeatureDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<ExteriorFeatureDto>, object>>> GetExteriorFeatureWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetExteriorFeatureWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified ExteriorFeature.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse ExteriorFeatureDto></returns>
		/// <response code = "200" > PaginatedList ExteriorFeatureDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> GetExteriorFeatureById(
				int id
		)
		{
			return await Mediator.Send(
				new GetExteriorFeatureByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified ExteriorFeature
		/// </summary>
		/// <param name="id"></param>
		/// <param name="ExteriorFeatureDto">ExteriorFeatureDto</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> UpdateExteriorFeature(
				int id,
				ExteriorFeatureDto ExteriorFeatureDto
		)
		{
			return await Mediator.Send(
				new UpdateExteriorFeatureCommand()
				{
					Id = id,
					ExteriorFeatureDto = ExteriorFeatureDto
				}
			);
		}

		/// <summary>
		/// Create a new ExteriorFeature
		/// </summary>
		/// <param name="ExteriorFeatureDto">ExteriorFeatureDto</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> CreateExteriorFeature(
				ExteriorFeatureDto ExteriorFeatureDto
		)
		{
			return await Mediator.Send(
				new CreateExteriorFeatureCommand()
				{
					ExteriorFeatureDto = ExteriorFeatureDto
				}
			);
		}

		/// <summary>
		/// Delete the specified ExteriorFeature
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> DeleteExteriorFeature(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteExteriorFeatureCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified ExteriorFeature
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ExteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableExteriorFeature/{id}")]
		public async Task<SlApiResponse<ExteriorFeatureDto, object>> DisableEnableExteriorFeature(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableExteriorFeatureCommand()
				{
					Id = id
				}
			);
		}
	}
}