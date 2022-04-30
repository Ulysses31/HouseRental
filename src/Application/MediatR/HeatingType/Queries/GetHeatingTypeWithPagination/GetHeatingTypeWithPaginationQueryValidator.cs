using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingType.Queries.GetHeatingTypeWithPagination
{
	/// <summary>
	/// GetHeatingTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetHeatingTypeWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetHeatingTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetHeatingTypeWithPaginationQueryValidator()
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