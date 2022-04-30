using FluentValidation;

namespace CleanArchitecture.Application.MediatR.FrameType.Queries.GetFrameTypeById
{
	/// <summary>
	/// GetFrameTypeWithPaginationQueryValidator class
	/// </summary>
	public class GetFrameTypeWithPaginationQueryValidator : AbstractValidator<GetFrameTypeByIdQuery>
	{
		/// <summary>
		/// GetFrameTypeWithPaginationQueryValidator constructor
		/// </summary>
		public GetFrameTypeWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}