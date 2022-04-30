using FluentValidation;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.CreateAdvertiserInfo
{
	public class CreateAdvertiserInfoCommandValidator : AbstractValidator<CreateAdvertiserInfoCommand>
	{
		public CreateAdvertiserInfoCommandValidator()
		{
			RuleFor(v => v.AdvertiserInfoDto)
				.NotNull();
		}
	}
}