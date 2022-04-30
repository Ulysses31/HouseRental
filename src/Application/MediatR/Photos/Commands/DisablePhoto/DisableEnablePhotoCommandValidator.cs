using CleanArchitecture.Application.MediatR.Photo.Commands.DisableEnablePhoto;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.Photo.Commands.DisableEnableFloorNo
{
	public class DisableEnablePhotoCommandValidator : AbstractValidator<DisableEnablePhotoCommand>
	{
		public DisableEnablePhotoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}