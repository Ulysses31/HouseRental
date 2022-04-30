using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FrameType.Commands.UpdateFrameType
{
	public class UpdateFrameTypeCommandValidator : AbstractValidator<UpdateFrameTypeCommand>
	{
		public UpdateFrameTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.FrameTypeDto)
				.NotNull();
		}
	}
}