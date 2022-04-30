using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Queries.GetInteriorFeatureWithPagination
{
	/// <summary>
	/// GetInteriorFeatureWithPaginationQueryValidator class
	/// </summary>
	public class GetInteriorFeatureWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetInteriorFeatureWithPaginationQueryValidator constructor
		/// </summary>
		public GetInteriorFeatureWithPaginationQueryValidator()
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