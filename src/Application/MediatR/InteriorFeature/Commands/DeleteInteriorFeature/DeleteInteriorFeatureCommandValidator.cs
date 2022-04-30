using FluentValidation;

namespace CleanArchitecture.Application.MediatR.InteriorFeature.Commands.DeleteInteriorFeature
{
	public class DeleteInteriorFeatureCommandValidator : AbstractValidator<DeleteInteriorFeatureCommand>
	{
		public DeleteInteriorFeatureCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}