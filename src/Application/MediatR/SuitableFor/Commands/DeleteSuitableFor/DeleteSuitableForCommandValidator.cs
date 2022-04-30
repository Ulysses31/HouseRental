using FluentValidation;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Commands.DeleteSuitableFor
{
	public class DeleteSuitableForCommandValidator : AbstractValidator<DeleteSuitableForCommand>
	{
		public DeleteSuitableForCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}