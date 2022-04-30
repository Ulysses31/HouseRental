using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Commands.DeleteClassifiedType
{
	public class DeleteClassifiedTypeCommandValidator : AbstractValidator<DeleteClassifiedTypeCommand>
	{
		public DeleteClassifiedTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}