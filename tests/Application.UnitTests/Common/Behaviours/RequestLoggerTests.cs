using CleanArchitecture.Application.Common.Behaviours;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.MediatR.AdvertiserInfo.Commands.CreateAdvertiserInfo;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UnitTests.Common.Behaviours
{
	public class RequestLoggerTests
	{
		private readonly Mock<ILogger<CreateAdvertiserInfoCommand>> _logger;
		private readonly Mock<ICurrentUserService> _currentUserService;
		private readonly Mock<IIdentityService> _identityService;

		public RequestLoggerTests()
		{
			_logger = new Mock<ILogger<CreateAdvertiserInfoCommand>>();
			_currentUserService = new Mock<ICurrentUserService>();
			_identityService = new Mock<IIdentityService>();
		}

		[Test]
		public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
		{
			_currentUserService.Setup(x => x.UserId).Returns("Administrator");

			var requestLogger = new LoggingBehaviour<CreateAdvertiserInfoCommand>(
				_logger.Object,
				_currentUserService.Object,
				_identityService.Object
			);

			await requestLogger.Process(
				new CreateAdvertiserInfoCommand
				{
					AdvertiserInfoDto = new Domain.DTOs.AdvertiserInfoDto()
					{
						Code = "TEST",
						Name = "LoggerTest",
						Address = "LoggerTest Address",
						Responsible = "LoggerTest",
						Telephone = "2310-000000",
						Email = "test@logger.com",
						Website = "logger.com",
						IsEnabled = true,
						IsDeleted = false
					}
				},
				new CancellationToken()
			);

			_identityService.Verify(
				i => i.GetUserNameAsync(It.IsAny<string>()),
				Times.Once
			);
		}

		[Test]
		public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
		{
			var requestLogger = new LoggingBehaviour<CreateAdvertiserInfoCommand>(
				_logger.Object,
				_currentUserService.Object,
				_identityService.Object
			);

			await requestLogger.Process(
				new CreateAdvertiserInfoCommand
				{
					AdvertiserInfoDto = new Domain.DTOs.AdvertiserInfoDto()
					{
						Code = "TEST",
						Name = "LoggerTest",
						Address = "LoggerTest Address",
						Responsible = "LoggerTest",
						Telephone = "2310-000000",
						Email = "test@logger.com",
						Website = "logger.com",
						IsEnabled = true,
						IsDeleted = false
					}
				},
				new CancellationToken()
			);

			_identityService.Verify(i => i.GetUserNameAsync(null), Times.Never);
		}
	}
}