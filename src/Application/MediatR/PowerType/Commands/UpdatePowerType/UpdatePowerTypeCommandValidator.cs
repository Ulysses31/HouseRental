using FluentValidation;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.UpdatePowerType
{
	public class UpdatePowerTypeCommandValidator : AbstractValidator<UpdatePowerTypeCommand>
	{
		public UpdatePowerTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.PowerTypeDto)
				.NotNull();
		}
	}
}