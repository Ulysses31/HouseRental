using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Queries.GetClassifiedTypeWithPagination
{
	/// <summary>
	/// GetClassifiedTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedTypeWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetClassifiedTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedTypeWithPaginationQueryValidator()
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