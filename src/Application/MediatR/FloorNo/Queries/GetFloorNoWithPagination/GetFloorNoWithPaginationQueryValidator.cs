using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorNo.Queries.GetFloorNoWithPagination
{
	/// <summary>
	/// GetFloorNoWithPaginationQueryValidator class
	/// </summary>
	public class GetFloorNoWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetFloorNoWithPaginationQueryValidator constructor
		/// </summary>
		public GetFloorNoWithPaginationQueryValidator()
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