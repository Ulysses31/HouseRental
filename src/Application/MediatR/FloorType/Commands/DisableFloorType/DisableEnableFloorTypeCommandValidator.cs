using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorType.Commands.DisableEnableFloorType
{
	public class DisableEnableFloorTypeCommandValidator : AbstractValidator<DisableEnableFloorTypeCommand>
	{
		public DisableEnableFloorTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}