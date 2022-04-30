using FluentValidation;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.DeleteAdvertiserInfo
{
	public class DeleteAdvertiserInfoCommandValidator : AbstractValidator<DeleteAdvertiserInfoCommand>
	{
		public DeleteAdvertiserInfoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}