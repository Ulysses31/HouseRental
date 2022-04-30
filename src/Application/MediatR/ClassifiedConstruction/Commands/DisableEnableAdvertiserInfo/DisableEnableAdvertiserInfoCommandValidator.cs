using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.DisableEnableClassifiedConstruction
{
	public class DisableEnableClassifiedConstructionCommandValidator : AbstractValidator<DisableEnableClassifiedConstructionCommand>
	{
		public DisableEnableClassifiedConstructionCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}