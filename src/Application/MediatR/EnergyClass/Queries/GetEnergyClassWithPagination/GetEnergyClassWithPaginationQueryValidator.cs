using CleanArchitecture.Application.Common.Models.Requests;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Queries.GetEnergyClassWithPagination
{
	/// <summary>
	/// GetEnergyClassWithPaginationQueryValidator class
	/// </summary>
	public class GetEnergyClassWithPaginationQueryValidator : AbstractValidator<SlApiPaginationQuery>
	{
		/// <summary>
		/// GetEnergyClassWithPaginationQueryValidator constructor
		/// </summary>
		public GetEnergyClassWithPaginationQueryValidator()
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