using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Commands.UpdateHeatingSystem
{
	public class UpdateHeatingSystemCommandValidator : AbstractValidator<UpdateHeatingSystemCommand>
	{
		public UpdateHeatingSystemCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.HeatingSystemDto)
				.NotNull();
		}
	}
}