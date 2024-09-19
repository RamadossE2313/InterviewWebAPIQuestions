using InterviewWebAPIQuestions.Models;
using InterviewWebAPIQuestions.Queries;
using InterviewWebAPIQuestions.Services;
using MediatR;

namespace InterviewWebAPIQuestions.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly IProductService _productService;

        public GetProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductsAsync();
        }
    }
}
