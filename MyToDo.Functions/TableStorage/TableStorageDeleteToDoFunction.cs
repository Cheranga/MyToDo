using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace MyToDo.Functions.TableStorage
{
    public static class TableStorageDeleteToDoFunction
    {
        [FunctionName("TableStorageDeleteToDoFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "tabletodos/{id}")]HttpRequest request,
            string id,
            [Table("todos", Connection = "AzureWebJobsStorage")]CloudTable table,
            ILogger logger
        )
        {
            var deleteOperation = TableOperation.Delete(new TableEntity("TODO", id)
            {
                ETag = "*"
            });

            try
            {
                var taskResult = await table.ExecuteAsync(deleteOperation).ConfigureAwait(false);
                if (taskResult.HttpStatusCode == 204)
                {
                    return new OkObjectResult("Todo deleted");
                }

                logger.LogError($"Error occured when trying to delete todo item {id} :: {taskResult.Result}");
                return new InternalServerErrorResult();
            }
            catch (StorageException exception) when (exception.RequestInformation.HttpStatusCode == (int) HttpStatusCode.NotFound)
            {
                var message = $"Todo not found: {id}";
                logger.LogError(message);
                return new NotFoundObjectResult(message);
            }
        }
    }
}