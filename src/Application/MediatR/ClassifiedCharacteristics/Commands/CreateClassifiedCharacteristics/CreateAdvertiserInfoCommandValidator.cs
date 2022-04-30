using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.CreateClassifiedCharacteristics
{
	public class CreateClassifiedCharacteristicsCommandValidator : AbstractValidator<CreateClassifiedCharacteristicsCommand>
	{
		public CreateClassifiedCharacteristicsCommandValidator()
		{
			RuleFor(v => v.ClassifiedCharacteristicsDto)
				.NotNull();
		}
	}
}