using FluentValidation;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.UpdateGoogleMapPlace
{
	public class UpdateGoogleMapPlaceCommandValidator : AbstractValidator<UpdateGoogleMapPlaceCommand>
	{
		public UpdateGoogleMapPlaceCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.GoogleMapPlaceDto)
				.NotNull();
		}
	}
}