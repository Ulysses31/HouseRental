using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FloorType.Queries.GetFloorTypeById
{
	/// <summary>
	/// GetFloorTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetFloorTypeWithPaginationQueryValidator : AbstractValidator<GetFloorTypeByIdQuery>
	{
		/// <summary>
		/// GetFloorTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetFloorTypeWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}