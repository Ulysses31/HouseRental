using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FrameType.Queries.GetFrameTypeWithPagination
{
	/// <summary>
	/// GetFrameTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetFrameTypeWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetFrameTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetFrameTypeWithPaginationQueryValidator()
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