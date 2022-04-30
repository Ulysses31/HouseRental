using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Queries.GetExteriorFeatureById
{
	/// <summary>
	/// GetExteriorFeatureWithPaginationQueryValidator class
	/// </summary>
	public class GetExteriorFeatureWithPaginationQueryValidator : AbstractValidator<GetExteriorFeatureByIdQuery>
	{
		/// <summary>
		/// GetExteriorFeatureWithPaginationQueryValidator constructor
		/// </summary>
		public GetExteriorFeatureWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}