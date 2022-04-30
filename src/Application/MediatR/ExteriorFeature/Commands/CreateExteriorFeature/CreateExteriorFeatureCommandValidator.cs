using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.CreateExteriorFeature
{
	public class CreateExteriorFeatureCommandValidator : AbstractValidator<CreateExteriorFeatureCommand>
	{
		public CreateExteriorFeatureCommandValidator()
		{
			RuleFor(v => v.ExteriorFeatureDto)
				.NotNull();
		}
	}
}