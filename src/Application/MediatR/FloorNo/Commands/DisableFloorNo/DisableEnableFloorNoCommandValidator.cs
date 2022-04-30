using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorNo.Commands.DisableEnableFloorNo
{
	public class DisableEnableFloorNoCommandValidator : AbstractValidator<DisableEnableFloorNoCommand>
	{
		public DisableEnableFloorNoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}