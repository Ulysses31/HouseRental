using FluentValidation;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.UpdatePhoto
{
	public class UpdatePhotoCommandValidator : AbstractValidator<UpdatePhotoCommand>
	{
		public UpdatePhotoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.PhotosDto)
				.NotNull();
		}
	}
}