using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingType.Commands.CreateHeatingType
{
	public class CreateHeatingTypeCommandValidator : AbstractValidator<CreateHeatingTypeCommand>
	{
		public CreateHeatingTypeCommandValidator()
		{
			RuleFor(v => v.HeatingTypeDto)
				.NotNull();
		}
	}
}