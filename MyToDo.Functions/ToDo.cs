using System;

namespace MyToDo.Functions
{
    public class ToDo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TaskDescription { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; }
    }
}