using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Queries.GetClassifiedConstructionWithPagination
{
	/// <summary>
	/// GetClassifiedConstructionWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedConstructionWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetClassifiedConstructionWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedConstructionWithPaginationQueryValidator()
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