//using CleanArchitecture.Application.Common.Models;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using System.Threading;
//using System.Threading.Tasks;

//namespace CleanArchitecture.Application.MediatR.TodoItems.EventHandlers
//{
//	public class TodoItemCompletedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCompletedEvent>>
//	{
//		private readonly ILogger<TodoItemCompletedEventHandler> _logger;

//		public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
//		{
//			_logger = logger;
//		}

//		public Task Handle(DomainEventNotification<TodoItemCompletedEvent> notification, CancellationToken cancellationToken)
//		{
//			var domainEvent = notification.DomainEvent;

//			_logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

//			return Task.CompletedTask;
//		}
//	}
//}