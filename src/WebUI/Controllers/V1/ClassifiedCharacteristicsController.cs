using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.CreateClassifiedCharacteristics;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.DeleteClassifiedCharacteristics;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.DisableEnableClassifiedCharacteristics;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.UpdateClassifiedCharacteristics;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Queries.GetClassifiedCharacteristicsById;
using CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Queries.GetClassifiedCharacteristicsWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// ClassifiedCharacteristicsController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class ClassifiedCharacteristicsController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassifiedCharacteristicsController"/> class.
		/// </summary>
		public ClassifiedCharacteristicsController()
		{
		}

		/// <summary>
		/// Gets the database ClassifiedCharacteristics with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList ClassifiedCharacteristicsDto</returns>
		/// <response code="200">PaginatedList ClassifiedCharacteristicsDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<ClassifiedCharacteristicsDto>, object>>> GetClassifiedCharacteristicsWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetClassifiedCharacteristicsWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified ClassifiedCharacteristics.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto></returns>
		/// <response code = "200" > PaginatedList ClassifiedCharacteristicsDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> GetClassifiedCharacteristicsById(
				int id
		)
		{
			return await Mediator.Send(
				new GetClassifiedCharacteristicsByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified ClassifiedCharacteristics
		/// </summary>
		/// <param name="id"></param>
		/// <param name="ClassifiedCharacteristicsDto">ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> UpdateClassifiedCharacteristics(
				int id,
				ClassifiedCharacteristicsDto ClassifiedCharacteristicsDto
		)
		{
			return await Mediator.Send(
				new UpdateClassifiedCharacteristicsCommand()
				{
					Id = id,
					ClassifiedCharacteristicsDto = ClassifiedCharacteristicsDto
				}
			);
		}

		/// <summary>
		/// Create a new ClassifiedCharacteristics
		/// </summary>
		/// <param name="ClassifiedCharacteristicsDto">ClassifiedCharacteristicsDto</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> CreateClassifiedCharacteristics(
				ClassifiedCharacteristicsDto ClassifiedCharacteristicsDto
		)
		{
			return await Mediator.Send(
				new CreateClassifiedCharacteristicsCommand()
				{
					ClassifiedCharacteristicsDto = ClassifiedCharacteristicsDto
				}
			);
		}

		/// <summary>
		/// Delete the specified ClassifiedCharacteristics
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DeleteClassifiedCharacteristics(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteClassifiedCharacteristicsCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified ClassifiedCharacteristics
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse ClassifiedCharacteristicsDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableClassifiedCharacteristics/{id}")]
		public async Task<SlApiResponse<ClassifiedCharacteristicsDto, object>> DisableEnableClassifiedCharacteristics(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableClassifiedCharacteristicsCommand()
				{
					Id = id
				}
			);
		}
	}
}