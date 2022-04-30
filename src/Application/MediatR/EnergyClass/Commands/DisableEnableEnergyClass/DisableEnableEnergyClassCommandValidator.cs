using FluentValidation;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Commands.DisableEnableEnergyClass
{
	public class DisableEnableEnergyClassCommandValidator : AbstractValidator<DisableEnableEnergyClassCommand>
	{
		public DisableEnableEnergyClassCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}