using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.CreateClassifiedConstruction
{
	public class CreateClassifiedConstructionCommandValidator : AbstractValidator<CreateClassifiedConstructionCommand>
	{
		public CreateClassifiedConstructionCommandValidator()
		{
			RuleFor(v => v.ClassifiedConstructionDto)
				.NotNull();
		}
	}
}