using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.UpdateExteriorFeature
{
	public class UpdateExteriorFeatureCommandValidator : AbstractValidator<UpdateExteriorFeatureCommand>
	{
		public UpdateExteriorFeatureCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.ExteriorFeatureDto)
				.NotNull();
		}
	}
}