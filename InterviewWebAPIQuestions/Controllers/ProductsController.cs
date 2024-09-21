using InterviewWebAPIQuestions.Commands;
using InterviewWebAPIQuestions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InterviewWebAPIQuestions.Controllers
{
    // Example of CQRS Pattern

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var products = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById) , new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var product = await _mediator.Send(command);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var success = await _mediator.Send(new DeleteProductCommand(id));
            return success ? NoContent() : NotFound();
        }
    }
}
