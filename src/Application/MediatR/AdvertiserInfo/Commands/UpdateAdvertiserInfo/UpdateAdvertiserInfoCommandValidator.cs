using FluentValidation;

namespace CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.UpdateAdvertiserInfo
{
	public class UpdateAdvertiserInfoCommandValidator : AbstractValidator<UpdateAdvertiserInfoCommand>
	{
		public UpdateAdvertiserInfoCommandValidator()
		{
			RuleFor(v => v.Id)
				.NotEmpty();
			RuleFor(v => v.AdvertiserInfoDto)
				.NotNull();
		}
	}
}