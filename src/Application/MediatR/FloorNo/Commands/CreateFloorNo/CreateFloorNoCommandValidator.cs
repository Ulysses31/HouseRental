using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorNo.Commands.CreateFloorNo
{
	public class CreateFloorNoCommandValidator : AbstractValidator<CreateFloorNoCommand>
	{
		public CreateFloorNoCommandValidator()
		{
			RuleFor(v => v.FloorNoDto)
				.NotNull();
		}
	}
}