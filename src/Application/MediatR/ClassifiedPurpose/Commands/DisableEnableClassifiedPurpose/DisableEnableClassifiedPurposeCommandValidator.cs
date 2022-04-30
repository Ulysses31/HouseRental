using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.DisableEnableClassifiedPurpose
{
	public class DisableEnableClassifiedPurposeCommandValidator : AbstractValidator<DisableEnableClassifiedPurposeCommand>
	{
		public DisableEnableClassifiedPurposeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}