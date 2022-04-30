using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.CreateClassifiedPurpose;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.DeleteClassifiedPurpose;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.DisableEnableClassifiedPurpose;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.UpdateClassifiedPurpose;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Queries.GetClassifiedPurposeById;
using CleanArchitecture.Application.MediatR.ClassifiedPurpose.Queries.GetClassifiedPurposeWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// ClassifiedPurposeController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class ClassifiedPurposeController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassifiedPurposeController"/> class.
		/// </summary>
		public ClassifiedPurposeController()
		{
		}

		/// <summary>
		/// Gets the database ClassifiedPurpose with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedPurposeDto</returns>
		/// <response code="200">PaginatedList ClassifiedPurposeDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<ClassifiedPurposeDto>, object>>> GetClassifiedPurposeWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetClassifiedPurposeWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified ClassifiedPurpose.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse ClassifiedPurposeDto></returns>
		/// <response code = "200" > PaginatedList ClassifiedPurposeDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> GetClassifiedPurposeById(
				int id
		)
		{
			return await Mediator.Send(
				new GetClassifiedPurposeByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified ClassifiedPurpose
		/// </summary>
		/// <param name="id"></param>
		/// <param name="ClassifiedPurposeDto">ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> UpdateClassifiedPurpose(
				int id,
				ClassifiedPurposeDto ClassifiedPurposeDto
		)
		{
			return await Mediator.Send(
				new UpdateClassifiedPurposeCommand()
				{
					Id = id,
					ClassifiedPurposeDto = ClassifiedPurposeDto
				}
			);
		}

		/// <summary>
		/// Create a new ClassifiedPurpose
		/// </summary>
		/// <param name="ClassifiedPurposeDto">ClassifiedPurposeDto</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> CreateClassifiedPurpose(
				ClassifiedPurposeDto ClassifiedPurposeDto
		)
		{
			return await Mediator.Send(
				new CreateClassifiedPurposeCommand()
				{
					ClassifiedPurposeDto = ClassifiedPurposeDto
				}
			);
		}

		/// <summary>
		/// Delete the specified ClassifiedPurpose
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> DeleteClassifiedPurpose(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteClassifiedPurposeCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified ClassifiedPurpose
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedPurposeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableClassifiedPurpose/{id}")]
		public async Task<SlApiResponse<ClassifiedPurposeDto, object>> DisableEnableClassifiedPurpose(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableClassifiedPurposeCommand()
				{
					Id = id
				}
			);
		}
	}
}