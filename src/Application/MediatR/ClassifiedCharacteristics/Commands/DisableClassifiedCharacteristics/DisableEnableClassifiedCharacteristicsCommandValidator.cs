using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.DisableEnableClassifiedCharacteristics
{
	public class DisableEnableClassifiedCharacteristicsCommandValidator : AbstractValidator<DisableEnableClassifiedCharacteristicsCommand>
	{
		public DisableEnableClassifiedCharacteristicsCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}