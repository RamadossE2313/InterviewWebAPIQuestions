using InterviewWebAPIQuestions.Commands;
using InterviewWebAPIQuestions.Models;
using InterviewWebAPIQuestions.Services;
using MediatR;

namespace InterviewWebAPIQuestions.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Implement the logic to update a product
            var products = await _productService.GetProductsAsync();
            var productToUpdate = products.FirstOrDefault(p => p.Id == request.Id);

            if (productToUpdate != null)
            {
                productToUpdate.Name = request.Name;
                // Normally, you'd save changes to the database here
            }

            return productToUpdate;
        }
    }
}
