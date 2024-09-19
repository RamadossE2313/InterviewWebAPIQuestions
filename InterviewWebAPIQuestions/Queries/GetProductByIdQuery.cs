using InterviewWebAPIQuestions.Models;
using MediatR;

namespace InterviewWebAPIQuestions.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
