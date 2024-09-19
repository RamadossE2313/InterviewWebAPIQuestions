using InterviewWebAPIQuestions.Commands;
using InterviewWebAPIQuestions.Services;
using MediatR;

namespace InterviewWebAPIQuestions.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductService _productService;

        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // Implement the logic to delete a product
            var products = await _productService.GetProductsAsync();
            var productToDelete = products.FirstOrDefault(p => p.Id == request.Id);

            if (productToDelete != null)
            {
                // Normally, you'd remove the product from the database here
                return true;
            }

            return false;
        }
    }
}
