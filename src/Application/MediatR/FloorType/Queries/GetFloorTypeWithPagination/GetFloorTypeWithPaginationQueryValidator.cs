using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorType.Queries.GetFloorTypeWithPagination
{
	/// <summary>
	/// GetFloorTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetFloorTypeWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetFloorTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetFloorTypeWithPaginationQueryValidator()
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