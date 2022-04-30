using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.UpdateClassifiedConstruction
{
	public class UpdateClassifiedConstructionCommandValidator : AbstractValidator<UpdateClassifiedConstructionCommand>
	{
		public UpdateClassifiedConstructionCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.ClassifiedConstructionDto)
				.NotNull();
		}
	}
}