using FluentValidation;

namespace CleanArchitecture.Application.MediatR.PowerType.Queries.GetPowerTypeById
{
	/// <summary>
	/// GetPowerTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetPowerTypeWithPaginationQueryValidator : AbstractValidator<GetPowerTypeByIdQuery>
	{
		/// <summary>
		/// GetPowerTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetPowerTypeWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}