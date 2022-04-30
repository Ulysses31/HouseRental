using FluentValidation;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Commands.DeleteGoogleMapPlace
{
	public class DeleteGoogleMapPlaceCommandValidator : AbstractValidator<DeleteGoogleMapPlaceCommand>
	{
		public DeleteGoogleMapPlaceCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}