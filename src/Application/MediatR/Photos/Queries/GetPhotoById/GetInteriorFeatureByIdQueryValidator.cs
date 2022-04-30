using FluentValidation;

namespace CleanArchitecture.Application.MediatR.Photo.Queries.GetPhotoById
{
	/// <summary>
	/// GetPhotoWithPaginationQueryValidator class
	/// </summary>
	public class GetPhotoWithPaginationQueryValidator : AbstractValidator<GetPhotoByIdQuery>
	{
		/// <summary>
		/// GetPhotoWithPaginationQueryValidator constructor
		/// </summary>
		public GetPhotoWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}