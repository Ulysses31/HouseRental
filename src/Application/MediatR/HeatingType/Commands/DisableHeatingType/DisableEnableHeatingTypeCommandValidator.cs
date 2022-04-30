using CleanArchitecture.Application.MediatR.HeatingType.Commands.DisableEnableHeatingType;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingType.Commands.DisableEnableFloorNo
{
	public class DisableEnableHeatingTypeCommandValidator : AbstractValidator<DisableEnableHeatingTypeCommand>
	{
		public DisableEnableHeatingTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}