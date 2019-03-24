using MyToDo.DataAccess.Cosmos;

namespace MyToDo.Functions.TableStorage
{
    public static class TableStorageExtensions
    {
        public static ToDoTableEntity ToTableEntity(this ToDo todo)
        {
            return new ToDoTableEntity
            {
                RowKey = todo.Id,
                PartitionKey = "TODO",
                TaskDescription = todo.TaskDescription,
                IsCompleted = todo.IsCompleted,
                CreatedTime = todo.CreatedTime
            };
        }

        public static ToDo ToToDo(this ToDoTableEntity tableEntity)
        {
            return new ToDo
            {
                Id = tableEntity.RowKey,
                TaskDescription = tableEntity.TaskDescription,
                IsCompleted = tableEntity.IsCompleted,
                CreatedTime = tableEntity.CreatedTime
            };
        }
    }
}