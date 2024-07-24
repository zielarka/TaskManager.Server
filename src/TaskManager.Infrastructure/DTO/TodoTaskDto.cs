using System;

namespace TaskManager.Infrastructure.DTO
{
    public class TodoTaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Status { get; set; }
    }
}
