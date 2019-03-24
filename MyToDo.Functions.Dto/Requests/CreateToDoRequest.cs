using System;
using System.Collections.Generic;
using System.Text;

namespace MyToDo.Functions.Dto.Requests
{
    public class CreateToDoRequest
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    }
}
