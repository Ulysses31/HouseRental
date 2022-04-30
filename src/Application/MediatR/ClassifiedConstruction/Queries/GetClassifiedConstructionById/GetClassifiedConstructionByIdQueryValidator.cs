using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedConstruction.Queries.GetClassifiedConstructionById
{
	/// <summary>
	/// GetClassifiedConstructionWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedConstructionWithPaginationQueryValidator : AbstractValidator<GetClassifiedConstructionByIdQuery>
	{
		/// <summary>
		/// GetClassifiedConstructionWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedConstructionWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}