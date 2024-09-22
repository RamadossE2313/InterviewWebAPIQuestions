using InterviewWebAPIQuestions.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewWebAPIQuestions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly CosmosDbService _cosmosDbService;

        public ItemsController(CosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(string id, [FromQuery] string partitionKey)
        {
            var response = await _cosmosDbService.GetItemAsync<dynamic>(id, partitionKey);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            return Ok(response.Resource.ToString());
        }
    }
}
