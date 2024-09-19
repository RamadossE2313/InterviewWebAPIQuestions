using InterviewWebAPIQuestions.Models;
using MediatR;

namespace InterviewWebAPIQuestions.Commands
{
    public record AddProductCommand(string Name) : IRequest<Product>;
}
