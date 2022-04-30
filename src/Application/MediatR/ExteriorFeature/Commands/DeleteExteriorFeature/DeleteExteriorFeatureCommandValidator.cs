using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ExteriorFeature.Commands.DeleteExteriorFeature
{
	public class DeleteExteriorFeatureCommandValidator : AbstractValidator<DeleteExteriorFeatureCommand>
	{
		public DeleteExteriorFeatureCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}