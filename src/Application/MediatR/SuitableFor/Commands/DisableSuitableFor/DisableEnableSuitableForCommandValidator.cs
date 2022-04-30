using FluentValidation;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Commands.DisableEnableSuitableFor
{
	public class DisableEnableSuitableForCommandValidator : AbstractValidator<DisableEnableSuitableForCommand>
	{
		public DisableEnableSuitableForCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}