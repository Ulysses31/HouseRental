using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.UpdateClassifiedPurpose
{
	public class UpdateClassifiedPurposeCommandValidator : AbstractValidator<UpdateClassifiedPurposeCommand>
	{
		public UpdateClassifiedPurposeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.ClassifiedPurposeDto)
				.NotNull();
		}
	}
}