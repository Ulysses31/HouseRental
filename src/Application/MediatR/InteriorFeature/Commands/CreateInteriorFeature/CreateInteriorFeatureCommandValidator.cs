using FluentValidation;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Commands.CreateInteriorFeature
{
	public class CreateInteriorFeatureCommandValidator : AbstractValidator<CreateInteriorFeatureCommand>
	{
		public CreateInteriorFeatureCommandValidator()
		{
			RuleFor(v => v.InteriorFeatureDto)
				.NotNull();
		}
	}
}