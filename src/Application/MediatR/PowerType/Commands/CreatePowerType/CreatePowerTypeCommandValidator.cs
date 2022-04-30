using FluentValidation;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.CreatePowerType
{
	public class CreatePowerTypeCommandValidator : AbstractValidator<CreatePowerTypeCommand>
	{
		public CreatePowerTypeCommandValidator()
		{
			RuleFor(v => v.PowerTypeDto)
				.NotNull();
		}
	}
}