using InterviewWebAPIQuestions.Core.Entities;

namespace InterviewWebAPIQuestions.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
    }
}
