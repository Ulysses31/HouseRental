using FluentValidation;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.DisableEnablePowerType
{
	public class DisableEnablePowerTypeCommandValidator : AbstractValidator<DisableEnablePowerTypeCommand>
	{
		public DisableEnablePowerTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}