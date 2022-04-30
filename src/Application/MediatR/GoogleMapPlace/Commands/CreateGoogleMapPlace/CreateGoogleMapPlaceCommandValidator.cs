using FluentValidation;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.CreateGoogleMapPlace
{
	public class CreateGoogleMapPlaceCommandValidator : AbstractValidator<CreateGoogleMapPlaceCommand>
	{
		public CreateGoogleMapPlaceCommandValidator()
		{
			RuleFor(v => v.GoogleMapPlaceDto)
				.NotNull();
		}
	}
}