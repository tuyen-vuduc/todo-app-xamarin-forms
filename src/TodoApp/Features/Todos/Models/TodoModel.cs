using System;

namespace TodoApp
{
    public class TodoModel : BaseModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class TodoEditingModel : TodoModel
    {
        public bool IsFlagged { get; internal set; }
        public DateTime DueDate { get; internal set; }
    }
}
