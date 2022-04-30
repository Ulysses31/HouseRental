using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Models.Responses
{
	public class SlApiMessage
	{
		public SlApiMessage()
		{
		}

		public SlApiMessageTypeEnum MessageType { get; set; } = SlApiMessageTypeEnum.Information;
		public string Message { get; set; } = "Success";
	}
}