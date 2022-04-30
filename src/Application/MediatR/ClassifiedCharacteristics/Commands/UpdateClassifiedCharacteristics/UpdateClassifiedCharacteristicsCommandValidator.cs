using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.UpdateClassifiedCharacteristics
{
	public class UpdateClassifiedCharacteristicsCommandValidator : AbstractValidator<UpdateClassifiedCharacteristicsCommand>
	{
		public UpdateClassifiedCharacteristicsCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.ClassifiedCharacteristicsDto)
				.NotNull();
		}
	}
}