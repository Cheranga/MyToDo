using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MyToDo.DataAccess.Cosmos;
using Newtonsoft.Json;

namespace MyToDo.Functions.TableStorage
{
    public static class TableStorageCreateToDoFunction
    {
        [FunctionName("TableStorageCreateToDoFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "tabletodos")]HttpRequest request,
            [Table("todos", Connection = "AzureWebJobsStorage")]IAsyncCollector<ToDoTableEntity> table,
            ILogger log)
        {
            log.LogInformation("TableStorage - Creating todo");

            var todo = JsonConvert.DeserializeObject<ToDo>(await new StreamReader(request.Body).ReadToEndAsync());
            if (todo == null)
            {
                return new BadRequestObjectResult("Invalid request");
            }

            await table.AddAsync(todo.ToTableEntity());

            return new OkObjectResult(todo);
        }
    }
}