using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Queries.GetHeatingSystemWithPagination
{
	/// <summary>
	/// GetHeatingSystemWithPaginationQueryValidator class
	/// </summary>
	public class GetHeatingSystemWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetHeatingSystemWithPaginationQueryValidator constructor
		/// </summary>
		public GetHeatingSystemWithPaginationQueryValidator()
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