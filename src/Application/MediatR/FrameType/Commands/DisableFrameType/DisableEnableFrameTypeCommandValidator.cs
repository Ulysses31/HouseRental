using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FrameType.Commands.DisableEnableFrameType
{
	public class DisableEnableFrameTypeCommandValidator : AbstractValidator<DisableEnableFrameTypeCommand>
	{
		public DisableEnableFrameTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}