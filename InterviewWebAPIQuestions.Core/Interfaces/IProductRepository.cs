using InterviewWebAPIQuestions.Core.Entities;

namespace InterviewWebAPIQuestions.Core.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
    }
}
