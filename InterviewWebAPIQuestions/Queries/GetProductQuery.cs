using InterviewWebAPIQuestions.Models;
using MediatR;

namespace InterviewWebAPIQuestions.Queries
{
    public record GetProductQuery : IRequest<IEnumerable<Product>>;
}
