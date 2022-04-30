using FluentValidation;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Commands.UpdateSuitableFor
{
	public class UpdateSuitableForCommandValidator : AbstractValidator<UpdateSuitableForCommand>
	{
		public UpdateSuitableForCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.SuitableForDto)
				.NotNull();
		}
	}
}