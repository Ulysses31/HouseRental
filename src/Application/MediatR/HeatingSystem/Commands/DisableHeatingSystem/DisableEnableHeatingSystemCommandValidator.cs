using CleanArchitecture.Application.MediatR.HeatingSystem.Commands.DisableEnableHeatingSystem;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Commands.DisableEnableFloorNo
{
	public class DisableEnableHeatingSystemCommandValidator : AbstractValidator<DisableEnableHeatingSystemCommand>
	{
		public DisableEnableHeatingSystemCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}