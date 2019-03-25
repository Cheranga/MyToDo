using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace MyToDo.DataAccess.TableStorage
{
    public class ToDoTableEntity : TableEntity
    {
        public DateTime CreatedTime { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }
    }
}
