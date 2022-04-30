using FluentValidation;

namespace CleanArchitecture.Application.MediatR.SuitableFor.Queries.GetSuitableForById
{
	/// <summary>
	/// GetSuitableForWithPaginationQueryValidator class
	/// </summary>
	public class GetSuitableForWithPaginationQueryValidator : AbstractValidator<GetSuitableForByIdQuery>
	{
		/// <summary>
		/// GetSuitableForWithPaginationQueryValidator constructor
		/// </summary>
		public GetSuitableForWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}