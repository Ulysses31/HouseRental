using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.WebUI.Controllers
{
	/// <summary>
	/// ApiControllerBase controller
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
	[ApiController]
	[Route("api/[controller]")]
	public abstract class ApiControllerBase : ControllerBase
	{
		private ISender _mediator;

		/// <summary>
		/// Gets the mediator.
		/// </summary>
		/// <value>
		/// The mediator.
		/// </value>
		protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
	}
}