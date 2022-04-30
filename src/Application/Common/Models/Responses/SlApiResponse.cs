using System.Collections.Generic;

namespace CleanArchitecture.Application.Common.Models.Responses
{
	public class SlApiResponse<T, M>
	{
		public SlApiResponse()
		{
		}

		public bool IsError { get; set; } = false;

		public IEnumerable<SlApiMessage> Messages { get; set; } = new List<SlApiMessage>() {
			new SlApiMessage() {
				MessageType = Domain.Enums.SlApiMessageTypeEnum.Information,
				Message = "Success"
			}
		};

		public T Data { get; set; }
		public M MetaData { get; set; }
	}
}