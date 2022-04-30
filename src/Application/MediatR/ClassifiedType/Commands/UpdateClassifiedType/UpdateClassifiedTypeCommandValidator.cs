using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Commands.UpdateClassifiedType
{
	public class UpdateClassifiedTypeCommandValidator : AbstractValidator<UpdateClassifiedTypeCommand>
	{
		public UpdateClassifiedTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.ClassifiedTypeDto)
				.NotNull();
		}
	}
}