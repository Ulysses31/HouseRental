using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Commands.DisableEnableClassifiedType
{
	public class DisableEnableClassifiedTypeCommandValidator : AbstractValidator<DisableEnableClassifiedTypeCommand>
	{
		public DisableEnableClassifiedTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}