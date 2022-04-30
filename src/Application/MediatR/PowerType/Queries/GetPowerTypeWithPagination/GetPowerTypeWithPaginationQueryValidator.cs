using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.PowerType.Queries.GetPowerTypeWithPagination
{
	/// <summary>
	/// GetPowerTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetPowerTypeWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetPowerTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetPowerTypeWithPaginationQueryValidator()
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