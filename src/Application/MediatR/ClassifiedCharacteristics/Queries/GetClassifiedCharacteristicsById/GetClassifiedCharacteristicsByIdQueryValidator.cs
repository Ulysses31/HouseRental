using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Queries.GetClassifiedCharacteristicsById
{
	/// <summary>
	/// GetClassifiedCharacteristicsWithPaginationQueryValidator class
	/// </summary>
	public class GetClassifiedCharacteristicsWithPaginationQueryValidator : AbstractValidator<GetClassifiedCharacteristicsByIdQuery>
	{
		/// <summary>
		/// GetClassifiedCharacteristicsWithPaginationQueryValidator constructor
		/// </summary>
		public GetClassifiedCharacteristicsWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}