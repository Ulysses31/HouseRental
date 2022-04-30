using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FrameType.Commands.DeleteFrameType
{
	public class DeleteFrameTypeCommandValidator : AbstractValidator<DeleteFrameTypeCommand>
	{
		public DeleteFrameTypeCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}