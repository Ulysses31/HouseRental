using FluentValidation;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Queries.GetInteriorFeatureById
{
	/// <summary>
	/// GetInteriorFeatureWithPaginationQueryValidator class
	/// </summary>
	public class GetInteriorFeatureWithPaginationQueryValidator : AbstractValidator<GetInteriorFeatureByIdQuery>
	{
		/// <summary>
		/// GetInteriorFeatureWithPaginationQueryValidator constructor
		/// </summary>
		public GetInteriorFeatureWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}