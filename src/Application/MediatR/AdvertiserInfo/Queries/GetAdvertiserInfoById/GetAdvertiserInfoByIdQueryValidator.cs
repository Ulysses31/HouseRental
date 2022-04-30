using FluentValidation;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Queries.GetAdvertiserInfoById
{
	/// <summary>
	/// GetAdvertiserInfoWithPaginationQueryValidator class
	/// </summary>
	public class GetAdvertiserInfoWithPaginationQueryValidator : AbstractValidator<GetAdvertiserInfoByIdQuery>
	{
		/// <summary>
		/// GetAdvertiserInfoWithPaginationQueryValidator constructor
		/// </summary>
		public GetAdvertiserInfoWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}