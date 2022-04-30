using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.CreateClassifiedPurpose
{
	public class CreateClassifiedPurposeCommandValidator : AbstractValidator<CreateClassifiedPurposeCommand>
	{
		public CreateClassifiedPurposeCommandValidator()
		{
			RuleFor(v => v.ClassifiedPurposeDto)
				.NotNull();
		}
	}
}