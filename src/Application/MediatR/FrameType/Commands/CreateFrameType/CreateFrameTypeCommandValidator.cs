using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FrameType.Commands.CreateFrameType
{
	public class CreateFrameTypeCommandValidator : AbstractValidator<CreateFrameTypeCommand>
	{
		public CreateFrameTypeCommandValidator()
		{
			RuleFor(v => v.FrameTypeDto)
				.NotNull();
		}
	}
}