using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedType.Commands.CreateClassifiedType;
using CleanArchitecture.Application.MediatR.ClassifiedType.Commands.DeleteClassifiedType;
using CleanArchitecture.Application.MediatR.ClassifiedType.Commands.DisableEnableClassifiedType;
using CleanArchitecture.Application.MediatR.ClassifiedType.Commands.UpdateClassifiedType;
using CleanArchitecture.Application.MediatR.ClassifiedType.Queries.GetClassifiedTypeById;
using CleanArchitecture.Application.MediatR.ClassifiedType.Queries.GetClassifiedTypeWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// ClassifiedTypeController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class ClassifiedTypeController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassifiedTypeController"/> class.
		/// </summary>
		public ClassifiedTypeController()
		{
		}

		/// <summary>
		/// Gets the database ClassifiedType with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedTypeDto</returns>
		/// <response code="200">PaginatedList ClassifiedTypeDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<ClassifiedTypeDto>, object>>> GetClassifiedTypeWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetClassifiedTypeWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified ClassifiedType.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse ClassifiedTypeDto></returns>
		/// <response code = "200" > PaginatedList ClassifiedTypeDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> GetClassifiedTypeById(
				int id
		)
		{
			return await Mediator.Send(
				new GetClassifiedTypeByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified ClassifiedType
		/// </summary>
		/// <param name="id"></param>
		/// <param name="ClassifiedTypeDto">ClassifiedTypeDto</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> UpdateClassifiedType(
				int id,
				ClassifiedTypeDto ClassifiedTypeDto
		)
		{
			return await Mediator.Send(
				new UpdateClassifiedTypeCommand()
				{
					Id = id,
					ClassifiedTypeDto = ClassifiedTypeDto
				}
			);
		}

		/// <summary>
		/// Create a new ClassifiedType
		/// </summary>
		/// <param name="ClassifiedTypeDto">ClassifiedTypeDto</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> CreateClassifiedType(
				ClassifiedTypeDto ClassifiedTypeDto
		)
		{
			return await Mediator.Send(
				new CreateClassifiedTypeCommand()
				{
					ClassifiedTypeDto = ClassifiedTypeDto
				}
			);
		}

		/// <summary>
		/// Delete the specified ClassifiedType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> DeleteClassifiedType(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteClassifiedTypeCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified ClassifiedType
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedTypeDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableClassifiedType/{id}")]
		public async Task<SlApiResponse<ClassifiedTypeDto, object>> DisableEnableClassifiedType(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableClassifiedTypeCommand()
				{
					Id = id
				}
			);
		}
	}
}