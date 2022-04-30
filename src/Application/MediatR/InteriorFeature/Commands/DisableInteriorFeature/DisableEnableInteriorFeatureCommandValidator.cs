using CleanArchitecture.Application.MediatR.InteriorFeature.Commands.DisableEnableInteriorFeature;
using FluentValidation;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Commands.DisableEnableFloorNo
{
	public class DisableEnableInteriorFeatureCommandValidator : AbstractValidator<DisableEnableInteriorFeatureCommand>
	{
		public DisableEnableInteriorFeatureCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}