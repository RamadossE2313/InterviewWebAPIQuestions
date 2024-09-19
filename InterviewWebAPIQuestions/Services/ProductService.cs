using InterviewWebAPIQuestions.Models;

namespace InterviewWebAPIQuestions.Services
{
    public class ProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            await Task.Delay(1000);
            return new List<Product>
            {
                new Product { Id = 1, Name = "test" }
            };
        }
    }
}
