using FluentValidation;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.DisableEnableGoogleMapPlace
{
	public class DisableEnableGoogleMapPlaceCommandValidator : AbstractValidator<DisableEnableGoogleMapPlaceCommand>
	{
		public DisableEnableGoogleMapPlaceCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}