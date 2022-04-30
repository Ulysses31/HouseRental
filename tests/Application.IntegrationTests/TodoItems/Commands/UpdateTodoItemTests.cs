﻿using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.MediatR.TodoItems.Commands.UpdateTodoItem;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IntegrationTests.TodoItems.Commands
{
	using static Testing;

	public class UpdateTodoItemTests : TestBase
	{
		[Test]
		public async Task ShouldRequireValidTodoItemId()
		{
			var command = new UpdateTodoItemCommand { Id = 99, Title = "New Title" };
			await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
		}

		[Test]
		public async Task ShouldUpdateTodoItem()
		{
			//var userId = await RunAsDefaultUserAsync();

			//var listId = await SendAsync(new CreateTodoListCommand
			//{
			//	Title = "New List"
			//});

			//var itemId = await SendAsync(new CreateTodoItemCommand
			//{
			//	ListId = listId,
			//	Title = "New Item"
			//});

			//var command = new UpdateTodoItemCommand
			//{
			//	Id = itemId,
			//	Title = "Updated Item Title"
			//};

			//await SendAsync(command);

			//var item = await FindAsync<TodoItem>(itemId);

			//item.Title.Should().Be(command.Title);
			//item.LastModifiedBy.Should().NotBeNull();
			//item.LastModifiedBy.Should().Be(userId);
			//item.LastModified.Should().NotBeNull();
			//item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
		}
	}
}