using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.CreateClassifiedConstruction;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.DeleteClassifiedConstruction;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.DisableEnableClassifiedConstruction;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.UpdateClassifiedConstruction;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Queries.GetClassifiedConstructionById;
using CleanArchitecture.Application.MediatR.ClassifiedConstruction.Queries.GetClassifiedConstructionWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// ClassifiedConstructionController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class ClassifiedConstructionController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassifiedConstructionController"/> class.
		/// </summary>
		public ClassifiedConstructionController()
		{
		}

		/// <summary>
		/// Gets the database ClassifiedConstruction with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedConstructionDto</returns>
		/// <response code="200">PaginatedList ClassifiedConstructionDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<ClassifiedConstructionDto>, object>>> GetClassifiedConstructionWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetClassifiedConstructionsWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified ClassifiedConstruction.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse ClassifiedConstructionDto></returns>
		/// <response code = "200" > PaginatedList ClassifiedConstructionDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> GetClassifiedConstructionById(
				int id
		)
		{
			return await Mediator.Send(
				new GetClassifiedConstructionByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified ClassifiedConstruction
		/// </summary>
		/// <param name="id"></param>
		/// <param name="ClassifiedConstructionDto">ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> UpdateClassifiedConstruction(
				int id,
				ClassifiedConstructionDto ClassifiedConstructionDto
		)
		{
			return await Mediator.Send(
				new UpdateClassifiedConstructionCommand()
				{
					Id = id,
					ClassifiedConstructionDto = ClassifiedConstructionDto
				}
			);
		}

		/// <summary>
		/// Create a new ClassifiedConstruction
		/// </summary>
		/// <param name="ClassifiedConstructionDto">ClassifiedConstructionDto</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> CreateClassifiedConstruction(
				ClassifiedConstructionDto ClassifiedConstructionDto
		)
		{
			return await Mediator.Send(
				new CreateClassifiedConstructionCommand()
				{
					ClassifiedConstructionDto = ClassifiedConstructionDto
				}
			);
		}

		/// <summary>
		/// Delete the specified ClassifiedConstruction
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> DeleteClassifiedConstruction(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteClassifiedConstructionCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified ClassifiedConstruction
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedConstructionDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableClassifiedConstruction/{id}")]
		public async Task<SlApiResponse<ClassifiedConstructionDto, object>> DisableEnableClassifiedConstruction(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableClassifiedConstructionCommand()
				{
					Id = id
				}
			);
		}
	}
}