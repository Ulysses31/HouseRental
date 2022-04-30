using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedType.Queries.GetClassifiedTypeById
{
	/// <summary>
	/// GetClassifiedTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedTypeWithPaginationQueryValidator : AbstractValidator<GetClassifiedTypeByIdQuery>
	{
		/// <summary>
		/// GetClassifiedTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedTypeWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}