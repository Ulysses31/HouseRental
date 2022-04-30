using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Commands.CreateClassifiedType
{
	public class CreateClassifiedTypeCommandValidator : AbstractValidator<CreateClassifiedTypeCommand>
	{
		public CreateClassifiedTypeCommandValidator()
		{
			RuleFor(v => v.ClassifiedTypeDto)
				.NotNull();
		}
	}
}