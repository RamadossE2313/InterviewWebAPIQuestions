using InterviewWebAPIQuestions.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewWebAPIQuestions.Api.Controllers.V2
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
             _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productRepository.GetProducts());
        }
    }
}
