using FluentValidation;

namespace CleanArchitecture.Application.MediatR.EnergyClass.Queries.GetEnergyClassById
{
	/// <summary>
	/// GetEnergyClassWithPaginationQueryValidator class
	/// </summary>
	public class GetEnergyClassWithPaginationQueryValidator : AbstractValidator<GetEnergyClassByIdQuery>
	{
		/// <summary>
		/// GetEnergyClassWithPaginationQueryValidator constructor
		/// </summary>
		public GetEnergyClassWithPaginationQueryValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id is required.");
		}
	}
}