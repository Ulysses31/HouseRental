using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Queries.GetAdvertiserInfoWithPagination
{
	/// <summary>
	/// GetAdvertiserInfoWithPaginationQueryValidator class
	/// </summary>
	public class GetAdvertiserInfoWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetAdvertiserInfoWithPaginationQueryValidator constructor
		/// </summary>
		public GetAdvertiserInfoWithPaginationQueryValidator()
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