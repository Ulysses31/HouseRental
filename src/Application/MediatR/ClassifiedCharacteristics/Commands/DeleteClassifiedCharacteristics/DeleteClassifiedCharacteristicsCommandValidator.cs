using FluentValidation;

namespace CleanArchitecture.Application.MediatR.ClassifiedCharacteristics.Commands.DeleteClassifiedCharacteristics
{
	public class DeleteClassifiedCharacteristicsCommandValidator : AbstractValidator<DeleteClassifiedCharacteristicsCommand>
	{
		public DeleteClassifiedCharacteristicsCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}