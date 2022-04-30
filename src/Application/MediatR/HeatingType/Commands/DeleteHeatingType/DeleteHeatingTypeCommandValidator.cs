using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingType.Commands.DeleteHeatingType
{
	public class DeleteHeatingTypeCommandValidator : AbstractValidator<DeleteHeatingTypeCommand>
	{
		public DeleteHeatingTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}