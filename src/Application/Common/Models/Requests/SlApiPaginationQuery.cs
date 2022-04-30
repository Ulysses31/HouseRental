namespace CleanArchitecture.Application.Common.Models.Requests
{
	public class SlApiPaginationQuery
	{
		public SlApiPaginationQuery()
		{
		}

		public int ListId { get; set; } = 0;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 10;
	}
}