using FluentValidation;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.DeletePhoto
{
	public class DeletePhotoCommandValidator : AbstractValidator<DeletePhotoCommand>
	{
		public DeletePhotoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}