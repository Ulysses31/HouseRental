using FluentValidation;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Commands.CreateEnergyClass
{
	public class CreateEnergyClassCommandValidator : AbstractValidator<CreateEnergyClassCommand>
	{
		public CreateEnergyClassCommandValidator()
		{
			RuleFor(v => v.EnergyClassDto)
				.NotNull();
		}
	}
}