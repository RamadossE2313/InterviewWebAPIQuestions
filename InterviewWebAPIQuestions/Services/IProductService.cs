using InterviewWebAPIQuestions.Models;

namespace InterviewWebAPIQuestions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
