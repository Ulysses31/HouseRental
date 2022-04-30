using FluentValidation;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.DisableEnableAdvertiserInfo
{
	public class DisableEnableAdvertiserInfoCommandValidator : AbstractValidator<DisableEnableAdvertiserInfoCommand>
	{
		public DisableEnableAdvertiserInfoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
		}
	}
}