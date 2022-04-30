using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingType.Commands.UpdateHeatingType
{
	public class UpdateHeatingTypeCommandValidator : AbstractValidator<UpdateHeatingTypeCommand>
	{
		public UpdateHeatingTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.HeatingTypeDto)
				.NotNull();
		}
	}
}