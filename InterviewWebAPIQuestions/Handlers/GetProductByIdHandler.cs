using InterviewWebAPIQuestions.Models;
using InterviewWebAPIQuestions.Queries;
using InterviewWebAPIQuestions.Services;
using MediatR;

namespace InterviewWebAPIQuestions.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductService _productService;

        public GetProductByIdHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsAsync();
            return products.FirstOrDefault();
        }
    }
}
