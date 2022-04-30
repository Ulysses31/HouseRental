using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.Photo.Queries.GetPhotoWithPagination
{
	/// <summary>
	/// GetPhotoWithPaginationQueryValidator class
	/// </summary>
	public class GetPhotoWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetPhotoWithPaginationQueryValidator constructor
		/// </summary>
		public GetPhotoWithPaginationQueryValidator()
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