using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Commands.DeleteClassifiedConstruction
{
	public class DeleteClassifiedConstructionCommandValidator : AbstractValidator<DeleteClassifiedConstructionCommand>
	{
		public DeleteClassifiedConstructionCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}