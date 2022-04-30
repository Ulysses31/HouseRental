using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorType.Commands.UpdateFloorType
{
	public class UpdateFloorTypeCommandValidator : AbstractValidator<UpdateFloorTypeCommand>
	{
		public UpdateFloorTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.FloorTypeDto)
				.NotNull();
		}
	}
}