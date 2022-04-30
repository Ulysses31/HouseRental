using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedPurpose.Queries.GetClassifiedPurposeById
{
	/// <summary>
	/// GetClassifiedPurposeWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedPurposeWithPaginationQueryValidator : AbstractValidator<GetClassifiedPurposeByIdQuery>
	{
		/// <summary>
		/// GetClassifiedPurposeWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedPurposeWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}