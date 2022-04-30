using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingType.Queries.GetHeatingTypeById
{
	/// <summary>
	/// GetHeatingTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetHeatingTypeWithPaginationQueryValidator : AbstractValidator<GetHeatingTypeByIdQuery>
	{
		/// <summary>
		/// GetHeatingTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetHeatingTypeWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}