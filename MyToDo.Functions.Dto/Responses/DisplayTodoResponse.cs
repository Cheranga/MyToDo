using System;

namespace MyToDo.Functions.Dto.Responses
{
    public class DisplayTodoResponse
    {
        public string Id { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}