using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Queries.GetClassifiedPurposeWithPagination
{
	/// <summary>
	/// GetClassifiedPurposeWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedPurposeWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetClassifiedPurposeWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedPurposeWithPaginationQueryValidator()
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