using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Commands.DeleteHeatingSystem
{
	public class DeleteHeatingSystemCommandValidator : AbstractValidator<DeleteHeatingSystemCommand>
	{
		public DeleteHeatingSystemCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}