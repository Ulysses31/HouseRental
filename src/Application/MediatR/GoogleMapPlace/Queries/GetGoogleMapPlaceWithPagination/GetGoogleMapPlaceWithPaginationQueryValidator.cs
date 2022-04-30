using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.GoogleMapPlace.Queries.GetGoogleMapPlaceWithPagination
{
	/// <summary>
	/// GetGoogleMapPlaceWithPaginationQueryValidator class
	/// </summary>
	public class GetGoogleMapPlaceWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetGoogleMapPlaceWithPaginationQueryValidator constructor
		/// </summary>
		public GetGoogleMapPlaceWithPaginationQueryValidator()
		{
			RuleFor(x => x.PageNumber)
				.GreaterThanOrEqualTo(1)
				.WithMessage("PageNumber at least greater than or equal to 1.");

			RuleFor(x => x.PageSize)
				.GreaterThanOrEqualTo(1)
				.WithMessage("PageSize at least greater than or equal to 1.");
		}
	}
}