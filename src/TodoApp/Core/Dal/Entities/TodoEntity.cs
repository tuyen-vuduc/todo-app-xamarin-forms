using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp
{
    [Table("Todos")]
    public class TodoEntity : Entity
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public bool IsDone { get; set; }
        public bool IsFlagged { get; set; }
        public DateTime DueDate { get; set; }
    }
}
