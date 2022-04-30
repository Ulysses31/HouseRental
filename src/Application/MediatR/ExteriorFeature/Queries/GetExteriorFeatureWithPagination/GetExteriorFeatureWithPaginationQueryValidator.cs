using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Queries.GetExteriorFeatureWithPagination
{
	/// <summary>
	/// GetExteriorFeatureWithPaginationQueryValidator class
	/// </summary>
	public class GetExteriorFeatureWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetExteriorFeatureWithPaginationQueryValidator constructor
		/// </summary>
		public GetExteriorFeatureWithPaginationQueryValidator()
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