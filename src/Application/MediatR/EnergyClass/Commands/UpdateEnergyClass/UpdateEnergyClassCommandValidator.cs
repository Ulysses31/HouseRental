using FluentValidation;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Commands.UpdateEnergyClass
{
	public class UpdateEnergyClassCommandValidator : AbstractValidator<UpdateEnergyClassCommand>
	{
		public UpdateEnergyClassCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.EnergyClassDto)
				.NotNull();
		}
	}
}