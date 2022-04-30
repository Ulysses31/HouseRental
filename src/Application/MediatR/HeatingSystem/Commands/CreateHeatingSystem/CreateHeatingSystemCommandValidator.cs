using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Commands.CreateHeatingSystem
{
	public class CreateHeatingSystemCommandValidator : AbstractValidator<CreateHeatingSystemCommand>
	{
		public CreateHeatingSystemCommandValidator()
		{
			RuleFor(v => v.HeatingSystemDto)
				.NotNull();
		}
	}
}