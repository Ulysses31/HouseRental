using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.Photo.Commands.CreatePhoto;
using CleanArchitecture.Application.MediatR.Photo.Commands.DeletePhoto;
using CleanArchitecture.Application.MediatR.Photo.Commands.DisableEnablePhoto;
using CleanArchitecture.Application.MediatR.Photo.Commands.UpdatePhoto;
using CleanArchitecture.Application.MediatR.Photo.Queries.GetPhotoById;
using CleanArchitecture.Application.MediatR.Photo.Queries.GetPhotoWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// PhotosController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class PhotosController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PhotosController"/> class.
		/// </summary>
		public PhotosController()
		{
		}

		/// <summary>
		/// Gets the database Photos with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList PhotosDto</returns>
		/// <response code="200">PaginatedList PhotosDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<PhotosDto>, object>>> GetPhotosWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetPhotoWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified Photos.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse PhotosDto></returns>
		/// <response code = "200" > PaginatedList PhotosDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<PhotosDto, object>> GetPhotosById(
				int id
		)
		{
			return await Mediator.Send(
				new GetPhotoByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified Photos
		/// </summary>
		/// <param name="id"></param>
		/// <param name="PhotosDto">PhotosDto</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<PhotosDto, object>> UpdatePhotos(
				int id,
				PhotosDto PhotosDto
		)
		{
			return await Mediator.Send(
				new UpdatePhotoCommand()
				{
					Id = id,
					PhotosDto = PhotosDto
				}
			);
		}

		/// <summary>
		/// Create a new Photos
		/// </summary>
		/// <param name="PhotosDto">PhotosDto</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<PhotosDto, object>> CreatePhotos(
				PhotosDto PhotosDto
		)
		{
			return await Mediator.Send(
				new CreatePhotoCommand()
				{
					PhotosDto = PhotosDto
				}
			);
		}

		/// <summary>
		/// Delete the specified Photos
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<PhotosDto, object>> DeletePhotos(
			int id
		)
		{
			return await Mediator.Send(
				new DeletePhotoCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified Photos
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse PhotosDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnablePhotos/{id}")]
		public async Task<SlApiResponse<PhotosDto, object>> DisableEnablePhotos(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnablePhotoCommand()
				{
					Id = id
				}
			);
		}
	}
}