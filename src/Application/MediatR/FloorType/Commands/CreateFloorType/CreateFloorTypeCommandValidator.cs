using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorType.Commands.CreateFloorType
{
	public class CreateFloorTypeCommandValidator : AbstractValidator<CreateFloorTypeCommand>
	{
		public CreateFloorTypeCommandValidator()
		{
			RuleFor(v => v.FloorTypeDto)
				.NotNull();
		}
	}
}