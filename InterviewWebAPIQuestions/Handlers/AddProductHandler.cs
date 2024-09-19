using InterviewWebAPIQuestions.Commands;
using InterviewWebAPIQuestions.Models;
using InterviewWebAPIQuestions.Services;
using MediatR;

namespace InterviewWebAPIQuestions.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductService _productService;

        public AddProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // Implement the logic to add a product
            // For example, simulate adding a product and return it
            var newProduct = new Product { Id = 2, Name = request.Name }; // Mock new product ID
                                                                          // Normally, you'd save this to a database here
            return await Task.FromResult(newProduct);
        }
    }
}
