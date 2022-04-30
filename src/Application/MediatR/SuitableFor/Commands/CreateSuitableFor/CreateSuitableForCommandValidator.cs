using FluentValidation;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Commands.CreateSuitableFor
{
	public class CreateSuitableForCommandValidator : AbstractValidator<CreateSuitableForCommand>
	{
		public CreateSuitableForCommandValidator()
		{
			RuleFor(v => v.SuitableForDto)
				.NotNull();
		}
	}
}