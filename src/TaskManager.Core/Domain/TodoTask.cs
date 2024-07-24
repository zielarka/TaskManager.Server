using System;
using TaskManager.Core.Enums;

namespace TaskManager.Core.Domain
{
    public class TodoTask
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DueDate { get; private set; }
        public TaskStatusEnum Status { get; private set; }

        public TodoTask(Guid id, string title, string description, DateTime? dueDate = null)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            DueDate = dueDate;
            Status = TaskStatusEnum.ToDo;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void UpdateDueDate(DateTime? dueDate)
        {
            DueDate = dueDate;
        }

        public void UpdateStatus(TaskStatusEnum status)
        {
            Status = status;
        }
    }
}
