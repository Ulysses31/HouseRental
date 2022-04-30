using System.Net;

namespace CleanArchitecture.Infrastructure.Services
{
	public class IpAddressService
	{
		public string GetHostIpAddress()
		{
			IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

			foreach (var item in ipHostInfo.AddressList)
			{
				if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					IPAddress ipAddress = item;
					return ipAddress.ToString();
				}
			}

			return null;
		}
	}
}