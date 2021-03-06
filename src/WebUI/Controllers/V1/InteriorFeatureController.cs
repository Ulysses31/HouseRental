using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.InteriorFeature.Commands.CreateInteriorFeature;
using CleanArchitecture.Application.MediatR.InteriorFeature.Commands.DeleteInteriorFeature;
using CleanArchitecture.Application.MediatR.InteriorFeature.Commands.DisableEnableInteriorFeature;
using CleanArchitecture.Application.MediatR.InteriorFeature.Commands.UpdateInteriorFeature;
using CleanArchitecture.Application.MediatR.InteriorFeature.Queries.GetInteriorFeatureById;
using CleanArchitecture.Application.MediatR.InteriorFeature.Queries.GetInteriorFeatureWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// InteriorFeatureController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class InteriorFeatureController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InteriorFeatureController"/> class.
		/// </summary>
		public InteriorFeatureController()
		{
		}

		/// <summary>
		/// Gets the database InteriorFeature with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList InteriorFeatureDto</returns>
		/// <response code="200">PaginatedList InteriorFeatureDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<InteriorFeatureDto>, object>>> GetInteriorFeatureWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetInteriorFeatureWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified InteriorFeature.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse InteriorFeatureDto></returns>
		/// <response code = "200" > PaginatedList InteriorFeatureDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<InteriorFeatureDto, object>> GetInteriorFeatureById(
				int id
		)
		{
			return await Mediator.Send(
				new GetInteriorFeatureByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified InteriorFeature
		/// </summary>
		/// <param name="id"></param>
		/// <param name="InteriorFeatureDto">InteriorFeatureDto</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<InteriorFeatureDto, object>> UpdateInteriorFeature(
				int id,
				InteriorFeatureDto InteriorFeatureDto
		)
		{
			return await Mediator.Send(
				new UpdateInteriorFeatureCommand()
				{
					Id = id,
					InteriorFeatureDto = InteriorFeatureDto
				}
			);
		}

		/// <summary>
		/// Create a new InteriorFeature
		/// </summary>
		/// <param name="InteriorFeatureDto">InteriorFeatureDto</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<InteriorFeatureDto, object>> CreateInteriorFeature(
				InteriorFeatureDto InteriorFeatureDto
		)
		{
			return await Mediator.Send(
				new CreateInteriorFeatureCommand()
				{
					InteriorFeatureDto = InteriorFeatureDto
				}
			);
		}

		/// <summary>
		/// Delete the specified InteriorFeature
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<InteriorFeatureDto, object>> DeleteInteriorFeature(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteInteriorFeatureCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified InteriorFeature
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse InteriorFeatureDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableInteriorFeature/{id}")]
		public async Task<SlApiResponse<InteriorFeatureDto, object>> DisableEnableInteriorFeature(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableInteriorFeatureCommand()
				{
					Id = id
				}
			);
		}
	}
}