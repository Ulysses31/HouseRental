using FluentValidation;

namespace CleanArchitecture.Application.MediatR.HeatingSystem.Queries.GetHeatingSystemById
{
	/// <summary>
	/// GetHeatingSystemWithPaginationQueryValidator class
	/// </summary>
	public class GetHeatingSystemWithPaginationQueryValidator : AbstractValidator<GetHeatingSystemByIdQuery>
	{
		/// <summary>
		/// GetHeatingSystemWithPaginationQueryValidator constructor
		/// </summary>
		public GetHeatingSystemWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}