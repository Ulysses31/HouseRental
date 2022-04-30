using FluentValidation;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Commands.UpdateInteriorFeature
{
	public class UpdateInteriorFeatureCommandValidator : AbstractValidator<UpdateInteriorFeatureCommand>
	{
		public UpdateInteriorFeatureCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.InteriorFeatureDto)
				.NotNull();
		}
	}
}