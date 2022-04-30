using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Commands.DeleteClassifiedPurpose
{
	public class DeleteClassifiedPurposeCommandValidator : AbstractValidator<DeleteClassifiedPurposeCommand>
	{
		public DeleteClassifiedPurposeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}