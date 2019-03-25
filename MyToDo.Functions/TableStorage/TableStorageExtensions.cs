using MyToDo.DataAccess.TableStorage;
using MyToDo.Functions.Dto.Requests;
using MyToDo.Functions.Dto.Responses;

namespace MyToDo.Functions.TableStorage
{
    public static class TableStorageExtensions
    {
        public static ToDoTableEntity ToTableEntity(this CreateToDoRequest request)
        {
            return new ToDoTableEntity
            {
                RowKey = request.Id,
                PartitionKey = "TODO",
                TaskDescription = request.TaskDescription,
                IsCompleted = request.IsCompleted,
                CreatedTime = request.CreatedTime
            };
        }

        public static DisplayTodoResponse ToDisplay(this ToDoTableEntity tableEntity)
        {
            return new DisplayTodoResponse
            {
                Id = tableEntity.RowKey,
                CreatedTime = tableEntity.CreatedTime,
                IsCompleted = tableEntity.IsCompleted,
                TaskDescription = tableEntity.TaskDescription
            };
        }
    }
}