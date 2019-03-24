using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using MyToDo.DataAccess.Cosmos;

namespace MyToDo.Functions.TableStorage
{
    public static class TableStorageGetAllToDosFunction
    {
        [FunctionName("TableStorageGetAllToDosFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tabletodos")] HttpRequest req,
            [Table("todos", Connection = "AzureWebJobsStorage")]CloudTable table,
            ILogger log)
        {
            log.LogInformation("Table Storage - Getting all todos");

            var query = new TableQuery<ToDoTableEntity>();
            var segment= await table.ExecuteQuerySegmentedAsync(query, null);
            if (segment.Results == null || !segment.Results.Any())
            {
                return new NotFoundObjectResult("There are no todos");
            }

            return new OkObjectResult(segment.Select(x=>x.ToDisplay()));
        }
    }
}
