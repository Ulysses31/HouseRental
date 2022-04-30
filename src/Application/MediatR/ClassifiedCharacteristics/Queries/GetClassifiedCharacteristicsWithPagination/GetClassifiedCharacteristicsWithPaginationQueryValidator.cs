using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Queries.GetClassifiedCharacteristicsWithPagination
{
	/// <summary>
	/// GetClassifiedCharacteristicsWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedCharacteristicsWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetClassifiedCharacteristicsWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedCharacteristicsWithPaginationQueryValidator()
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