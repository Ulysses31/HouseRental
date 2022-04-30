using FluentValidation;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.CreatePhoto
{
	public class CreatePhotoCommandValidator : AbstractValidator<CreatePhotoCommand>
	{
		public CreatePhotoCommandValidator()
		{
			RuleFor(v => v.PhotosDto)
				.NotNull();
		}
	}
}