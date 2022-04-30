using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Requests;
using CleanArchitecture.Application.Common.Models.Responses;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.CreateAdvertiserInfo;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.DeleteAdvertiserInfo;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.DisableEnableAdvertiserInfo;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.UpdateAdvertiserInfo;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Queries.GetAdvertiserInfoById;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Queries.GetAdvertiserInfoWithPagination;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers.V1
{
	/// <summary>
	/// AdvertiserInfoController controller
	/// </summary>
	/// <seealso cref="CleanArchitecture.WebUI.Controllers.ApiControllerBase" />
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[Consumes("application/json", "application/xml")]
	[Produces("application/json", "application/xml")]
	public class AdvertiserInfoController : ApiControllerBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AdvertiserInfoController"/> class.
		/// </summary>
		public AdvertiserInfoController()
		{
		}

		/// <summary>
		/// Gets the database AdvertiserInfo with pagination.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>SlApiResponse PaginatedList AdvertiserInfoDto</returns>
		/// <response code="200">PaginatedList AdvertiserInfoDto</response>
		/// <response code="401">Unauthorized</response>
		/// <response code="400">Bad Request</response>
		/// <response code="404">Not Found</response>
		/// <response code="406">Not Acceptable</response>
		/// <response code="500">Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet]
		public async Task<ActionResult<SlApiResponse<PaginatedList<AdvertiserInfoDto>, object>>> GetAdvertiserInfoWithPagination(
			[FromQuery] SlApiPaginationQuery query
		)
		{
			return await Mediator.Send(
				new GetAdvertiserInfosWithPaginationQuery()
				{
					query = query
				}
			);
		}

		/// <summary>
		/// Gets the specified AdvertiserInfo.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>SlApiResponse AdvertiserInfoDto></returns>
		/// <response code = "200" > PaginatedList AdvertiserInfoDto</response>
		/// <response code = "401" > Unauthorized </response >
		/// <response code= "400" > Bad Request</response>
		/// <response code = "404" > Not Found</response>
		/// <response code = "406" > Not Acceptable</response>
		/// <response code = "500" > Internal Server Error</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpGet("{id}")]
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> GetAdvertiserInfoById(
				int id
		)
		{
			return await Mediator.Send(
				new GetAdvertiserInfoByIdQuery() { Id = id }
			);
		}

		/// <summary>
		/// Update the specified AdvertiserInfo
		/// </summary>
		/// <param name="id"></param>
		/// <param name="advertiserInfoDto">AdvertiserInfoDto</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("{id}")]
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> UpdateAdvertiserInfo(
				int id,
				AdvertiserInfoDto advertiserInfoDto
		)
		{
			return await Mediator.Send(
				new UpdateAdvertiserInfoCommand()
				{
					Id = id,
					AdvertiserInfoDto = advertiserInfoDto
				}
			);
		}

		/// <summary>
		/// Create a new AdvertiserInfo
		/// </summary>
		/// <param name="advertiserInfoDto">AdvertiserInfoDto</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> CreateAdvertiserInfo(
				AdvertiserInfoDto advertiserInfoDto
		)
		{
			return await Mediator.Send(
				new CreateAdvertiserInfoCommand()
				{
					AdvertiserInfoDto = advertiserInfoDto
				}
			);
		}

		/// <summary>
		/// Delete the specified AdvertiserInfo
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpDelete("{id}")]
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> DeleteAdvertiserInfo(
			int id
		)
		{
			return await Mediator.Send(
				new DeleteAdvertiserInfoCommand() { Id = id }
			);
		}

		/// <summary>
		/// Virtualy delete the specified AdvertiserInfo
		/// </summary>
		/// <param name="id">int</param>
		/// <returns>SlApiResponse AdvertiserInfoDto</returns>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[MapToApiVersion("1.0")]
		[HttpPut("DisableEnableAdvertiserInfo/{id}")]
		public async Task<SlApiResponse<AdvertiserInfoDto, object>> DisableEnableAdvertiserInfo(
			int id
		)
		{
			return await Mediator.Send(
				new DisableEnableAdvertiserInfoCommand()
				{
					Id = id
				}
			);
		}
	}
}