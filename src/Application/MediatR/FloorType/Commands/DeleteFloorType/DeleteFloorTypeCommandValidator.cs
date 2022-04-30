using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorType.Commands.DeleteFloorType
{
	public class DeleteFloorTypeCommandValidator : AbstractValidator<DeleteFloorTypeCommand>
	{
		public DeleteFloorTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}