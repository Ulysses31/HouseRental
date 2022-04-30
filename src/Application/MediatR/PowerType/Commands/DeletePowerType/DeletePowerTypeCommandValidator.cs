using FluentValidation;

namespace CleanArchitecture.Application.MediatR.PowerType.Commands.DeletePowerType
{
	public class DeletePowerTypeCommandValidator : AbstractValidator<DeletePowerTypeCommand>
	{
		public DeletePowerTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}