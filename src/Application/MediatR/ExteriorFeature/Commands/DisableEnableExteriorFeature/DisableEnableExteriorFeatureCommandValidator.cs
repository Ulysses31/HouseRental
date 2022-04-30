using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.DisableEnableExteriorFeature
{
	public class DisableEnableExteriorFeatureCommandValidator : AbstractValidator<DisableEnableExteriorFeatureCommand>
	{
		public DisableEnableExteriorFeatureCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}