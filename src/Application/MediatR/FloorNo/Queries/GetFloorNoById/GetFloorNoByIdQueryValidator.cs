using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorNo.Queries.GetFloorNoById
{
	/// <summary>
	/// GetFloorNoWithPaginationQueryValidator class
	/// </summary>
	public class GetFloorNoWithPaginationQueryValidator : AbstractValidator<GetFloorNoByIdQuery>
	{
		/// <summary>
		/// GetFloorNoWithPaginationQueryValidator constructor
		/// </summary>
		public GetFloorNoWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}