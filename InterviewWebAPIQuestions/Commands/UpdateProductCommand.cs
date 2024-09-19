using InterviewWebAPIQuestions.Models;
using MediatR;

namespace InterviewWebAPIQuestions.Commands
{
    public record UpdateProductCommand (int Id, string Name) : IRequest<Product>;
}
