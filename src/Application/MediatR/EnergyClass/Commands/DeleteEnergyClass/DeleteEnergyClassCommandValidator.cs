using FluentValidation;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Commands.DeleteEnergyClass
{
	public class DeleteEnergyClassCommandValidator : AbstractValidator<DeleteEnergyClassCommand>
	{
		public DeleteEnergyClassCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}