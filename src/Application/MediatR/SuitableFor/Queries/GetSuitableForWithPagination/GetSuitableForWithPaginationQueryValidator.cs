using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Queries.GetSuitableForWithPagination
{
	/// <summary>
	/// GetSuitableForWithPaginationQueryValidator class
	/// </summary>
	public class GetSuitableForWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetSuitableForWithPaginationQueryValidator constructor
		/// </summary>
		public GetSuitableForWithPaginationQueryValidator()
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