using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorNo.Commands.DeleteFloorNo
{
	public class DeleteFloorNoCommandValidator : AbstractValidator<DeleteFloorNoCommand>
	{
		public DeleteFloorNoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}