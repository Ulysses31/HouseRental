using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorNo.Commands.UpdateFloorNo
{
	public class UpdateFloorNoCommandValidator : AbstractValidator<UpdateFloorNoCommand>
	{
		public UpdateFloorNoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.FloorNoDto)
				.NotNull();
		}
	}
}