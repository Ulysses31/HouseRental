using FluentValidation;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Queries.GetGoogleMapPlaceById
{
	/// <summary>
	/// GetGoogleMapPlaceWithPaginationQueryValidator class
	/// </summary>
	public class GetGoogleMapPlaceWithPaginationQueryValidator : AbstractValidator<GetGoogleMapPlaceByIdQuery>
	{
		/// <summary>
		/// GetGoogleMapPlaceWithPaginationQueryValidator constructor
		/// </summary>
		public GetGoogleMapPlaceWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}