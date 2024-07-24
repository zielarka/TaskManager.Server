using System;
using TaskManager.Core.Domain;
using TaskManager.Core.Enums;
using Xunit;

namespace TaskManager.Tests.Domain
{
    public class TodoTaskTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var title = "Sample Task";
            var description = "This is a sample task description";
            var dueDate = DateTime.Now.AddDays(1);

            // Act
            var todoTask = new TodoTask(id, title, description, dueDate);

            // Assert
            Assert.Equal(id, todoTask.Id);
            Assert.Equal(title, todoTask.Title);
            Assert.Equal(description, todoTask.Description);
            Assert.Equal(DateTime.Now.Date, todoTask.CreatedAt.Date); // Allowing date comparison
            Assert.Equal(dueDate, todoTask.DueDate);
            Assert.Equal(TaskStatusEnum.ToDo, todoTask.Status);
        }

        [Fact]
        public void Constructor_ShouldInitializeWithNullDueDate()
        {
            // Arrange
            var id = Guid.NewGuid();
            var title = "Sample Task";
            var description = "This is a sample task description";

            // Act
            var todoTask = new TodoTask(id, title, description);

            // Assert
            Assert.Equal(id, todoTask.Id);
            Assert.Equal(title, todoTask.Title);
            Assert.Equal(description, todoTask.Description);
            Assert.Equal(DateTime.Now.Date, todoTask.CreatedAt.Date);
            Assert.Null(todoTask.DueDate);
            Assert.Equal(TaskStatusEnum.ToDo, todoTask.Status);
        }

        [Fact]
        public void UpdateTitle_ShouldChangeTitle()
        {
            // Arrange
            var todoTask = new TodoTask(Guid.NewGuid(), "Old Title", "Description");
            var newTitle = "New Title";

            // Act
            todoTask.UpdateTitle(newTitle);

            // Assert
            Assert.Equal(newTitle, todoTask.Title);
        }

        [Fact]
        public void UpdateDescription_ShouldChangeDescription()
        {
            // Arrange
            var todoTask = new TodoTask(Guid.NewGuid(), "Title", "Old Description");
            var newDescription = "New Description";

            // Act
            todoTask.UpdateDescription(newDescription);

            // Assert
            Assert.Equal(newDescription, todoTask.Description);
        }

        [Fact]
        public void UpdateDueDate_ShouldChangeDueDate()
        {
            // Arrange
            var todoTask = new TodoTask(Guid.NewGuid(), "Title", "Description");
            var newDueDate = DateTime.Now.AddDays(5);

            // Act
            todoTask.UpdateDueDate(newDueDate);

            // Assert
            Assert.Equal(newDueDate, todoTask.DueDate);
        }

        [Fact]
        public void UpdateStatus_ShouldChangeStatus()
        {
            // Arrange
            var todoTask = new TodoTask(Guid.NewGuid(), "Title", "Description");
            var newStatus = TaskStatusEnum.InProgress;

            // Act
            todoTask.UpdateStatus(newStatus);

            // Assert
            Assert.Equal(newStatus, todoTask.Status);
        }
    }
}
