using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.CreateGoogleMapPlace;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.DeleteGoogleMapPlace;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.DisableEnableGoogleMapPlace;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.UpdateGoogleMapPlace;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Queries.GetGoogleMapPlaceById;
using CleanArchitecture.Application.MediatR.GoogleMapPlace.Queries.GetGoogleMapPlaceWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// GoogleMapPlaceController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class GoogleMapPlaceController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GoogleMapPlaceController"/> class.
		/// </summary>
		public GoogleMapPlaceController()
		{
		}

		/// <summary>
		/// Gets the database GoogleMapPlace with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList GoogleMapPlaceDto</returns>
		/// <response code="200">PaginatedList GoogleMapPlaceDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<GoogleMapPlaceDto>, object>>> GetGoogleMapPlaceWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetGoogleMapPlaceWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified GoogleMapPlace.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse GoogleMapPlaceDto></returns>
		/// <response code = "200" > PaginatedList GoogleMapPlaceDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> GetGoogleMapPlaceById(
				int id
		)
		{
			return await Mediator.Send(
				new GetGoogleMapPlaceByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified GoogleMapPlace
		/// </summary>
		/// <param name="id"></param>
		/// <param name="GoogleMapPlaceDto">GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> UpdateGoogleMapPlace(
				int id,
				GoogleMapPlaceDto GoogleMapPlaceDto
		)
		{
			return await Mediator.Send(
				new UpdateGoogleMapPlaceCommand()
				{
					Id = id,
					GoogleMapPlaceDto = GoogleMapPlaceDto
				}
			);
		}

		/// <summary>
		/// Create a new GoogleMapPlace
		/// </summary>
		/// <param name="GoogleMapPlaceDto">GoogleMapPlaceDto</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> CreateGoogleMapPlace(
				GoogleMapPlaceDto GoogleMapPlaceDto
		)
		{
			return await Mediator.Send(
				new CreateGoogleMapPlaceCommand()
				{
					GoogleMapPlaceDto = GoogleMapPlaceDto
				}
			);
		}

		/// <summary>
		/// Delete the specified GoogleMapPlace
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> DeleteGoogleMapPlace(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteGoogleMapPlaceCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified GoogleMapPlace
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse GoogleMapPlaceDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableGoogleMapPlace/{id}")]
		public async Task<SlApiResponse<GoogleMapPlaceDto, object>> DisableEnableGoogleMapPlace(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableGoogleMapPlaceCommand()
				{
					Id = id
				}
			);
		}
	}
}